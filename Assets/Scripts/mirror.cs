using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
    private List<GameObject> list_to_reflect;
    private GameObject player;
    public Collider2D[] Colliders;
    public Collider2D[] Batteries;

    public bool isHauntedMirror = false;
    public GameObject realEnemyPrefab;

    public float enemyDetection = 1;
    
    public float radius = 20f;

    bool need_to_reflect = true;
    bool player_to_reflect = false;
    public GameObject copy_player_prefab;
    private GameObject copy_player;
    // Start is called before the first frame update

    public float timeSee = 0.5f;  // Taux de tir, un tir toutes les 0.25 secondes.
    private float nextStopSee = 0f;
    private EnemyAI NEmy;
    void Start()
    {
        player = GameManager.player.gameObject;
        Vector3 center = gameObject.transform.position;
        Colliders = Physics2D.OverlapCircleAll(center, radius, 1);
        gameObject.GetComponent<CircleCollider2D>().radius = radius;
        if (isHauntedMirror)
        {
            copy_player = Instantiate(realEnemyPrefab, player.transform.position,Quaternion.identity);
            NEmy = copy_player.GetComponent<EnemyAI>();
            NEmy.enabled = false;
        }
        else
        {
            copy_player = Instantiate(copy_player_prefab, player.transform.position,Quaternion.identity);
        }
        //copy_player.GetComponent<player>().enabled = false;
        copy_player.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f,1f,1f,0.0f);
    }

    void GetStaticObjects()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {

    }

    void reflectWall()
    {
        foreach(Collider2D col in Colliders)
        {
            Vector3 position = col.gameObject.transform.position;
            Vector3 relative_post = this.gameObject.transform.InverseTransformPoint(position);
            Vector3 miroir = this.gameObject.transform.position;

            Vector3 new_post = new Vector3(relative_post.x,relative_post.y*-1,relative_post.z);
            new_post = gameObject.transform.TransformPoint(new_post);

            GameObject instantiated = Instantiate(col.gameObject, new_post, Quaternion.identity);
            float diff_angle = this.gameObject.transform.rotation.eulerAngles.z - col.gameObject.transform.rotation.eulerAngles.z;
            instantiated.transform.Rotate(0,0,(this.gameObject.transform.rotation.eulerAngles.z+diff_angle));
            instantiated.layer = 16;
            instantiated.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.5f);
            instantiated.GetComponent<SpriteRenderer>().flipY = true;

            if(col.gameObject.CompareTag("battery"))
            {
                col.GetComponent<battery>().AddReflection(instantiated);
            }

        }
    }

    void reflectPlayer()
    {
        if(player_to_reflect)
        {
            Vector3 position = player.transform.position;
            Vector3 relative_post = this.gameObject.transform.InverseTransformPoint(position);
            Vector3 miroir = this.gameObject.transform.position;

            Vector3 new_post = new Vector3(relative_post.x,relative_post.y*-1,relative_post.z);
            new_post = gameObject.transform.TransformPoint(new_post);

            copy_player.transform.position = new_post;
            float diff_angle = this.gameObject.transform.rotation.eulerAngles.z - player.gameObject.transform.rotation.eulerAngles.z;
            copy_player.transform.eulerAngles = new Vector3(0,0,(this.gameObject.transform.rotation.eulerAngles.z + diff_angle+180));
            copy_player.layer = 16;
            
            copy_player.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.5f);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if(need_to_reflect)
        {
            need_to_reflect=false;
            reflectWall();
        }

        if (copy_player == null)
        {
            return ;
        }

        float distanceBetweenPlayerAndEnemy = Vector3.Distance(copy_player.transform.position, player.transform.position);
        if (isHauntedMirror && distanceBetweenPlayerAndEnemy < enemyDetection)
        {
            NEmy.enabled = true;
            return;
        }
        else
        {
            reflectPlayer();
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player_to_reflect = true;
            copy_player.SetActive(true);
            reflectPlayer();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {  
            Debug.Log("Les berets");
            copy_player.SetActive(false);
            player_to_reflect = false;
        }
    }
}
