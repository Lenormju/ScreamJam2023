using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float timeSee = 0.5f;  
    public float nextStopSee = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextStopSee)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            nextStopSee = Time.time + timeSee;
        }
    }
}
