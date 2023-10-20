using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
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
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.CompareTag("Player")){
            Debug.Log("Banane");
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.CompareTag("Player")){
            Debug.Log("Banane2");
        }
        
    }
}
