using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battery : MonoBehaviour
{
    public GameObject battery_level;

    // Start is called before the first frame update
    void Start()
    {
        battery_level = GameObject.Find("BatteryLevel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
        battery_level.GetComponent<Slider>().value += 10;
    }
}
