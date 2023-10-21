using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{

    public SpriteRenderer sp_fantome;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")){
            Debug.Log("Toc toc ! entrez !");
            sp_fantome.enabled = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")){
            Debug.Log("Dégage");
            sp_fantome.enabled = false;
        }
        
    }
}
