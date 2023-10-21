using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
    public GameObject player;
    public GameObject fantome;
    SpriteRenderer _spFantome;

    // Start is called before the first frame update
    void Start()
    {
     _spFantome = fantome.GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        fantome.transform.position = new Vector3(player.transform.position.x, Mathf.Abs(player.transform.position.y), 0);
        float scaleRatio = 3f / (1 + 0.2f * Mathf.Abs(player.transform.position.y));
        fantome.transform.localScale = new Vector3(scaleRatio, scaleRatio, 0); 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")){
            Debug.Log("Toc toc ! entrez !");
            _spFantome.enabled = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")){
            Debug.Log("Dégage");
            _spFantome.enabled = false;
        }
        
    }
}
