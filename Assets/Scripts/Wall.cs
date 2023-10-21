using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float timeSee = 0.5f;  // Taux de tir, un tir toutes les 0.25 secondes.
    private float nextStopSee = 0f;

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
            timeSee = Time.time + nextStopSee;
        }
    }

    void seen()
    {


    }
}
