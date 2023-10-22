using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class battery : MonoBehaviour
{
    
    public List<GameObject> reflections;
    public void AddReflection(GameObject p_reflect)
    {
        reflections.Add(p_reflect);
    }

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
            
            foreach(GameObject reflect in reflections)
            {
                Destroy(reflect);
            }
            Destroy(gameObject);
            
            GameManager.battery_level +=10;
        }
    }

}
