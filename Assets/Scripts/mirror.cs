using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
    private List<GameObject> list_to_reflect;
    public GameObject player;
    private Collider2D[] Colliders;
    public float radius = 20f;
    private List<GameObject> list_to_reflect;
    public GameObject player;
    private Collider2D[] Colliders;
    public float radius = 20f;

    bool player_to_reflect = false;
    public GameObject copy_player_prefab;
    private GameObject copy_player;
    // Start is called before the first frame update

    public float timeSee = 0.5f;  // Taux de tir, un tir toutes les 0.25 secondes.
    private float nextStopSee = 0f;
    void Start()
    {
        Vector3 center = gameObject.transform.position;
        Colliders = Physics2D.OverlapCircleAll(center, radius, 1);
        gameObject.GetComponent<CircleCollider2D>().radius = radius;
        copy_player = Instantiate(copy_player_prefab, player.transform.position,Quaternion.identity);
        //copy_player.GetComponent<player>().enabled = false;
        copy_player.SetActive(false);
        reflectWall();

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
        reflectPlayer();

        if(Time.time > nextStopSee)
        {
            GetComponentInParent<SpriteRenderer>().enabled = false;
            timeSee = Time.time + nextStopSee;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            copy_player.SetActive(true);
            player_to_reflect = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {  
            copy_player.SetActive(false);
            player_to_reflect = false;
        }
    }
}
