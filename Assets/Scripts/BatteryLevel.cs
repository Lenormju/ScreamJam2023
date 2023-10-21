using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryLevel : MonoBehaviour
{
    Slider _battery_level;
    public float battery_consumption = 1;

    // Start is called before the first frame update
    void Start()
    {
        _battery_level = GetComponent<Slider>();
        _battery_level.maxValue = GameManager.battery_level_start;
    }

    // Update is called once per frame
    void Update()
    {
        _battery_level.value = GameManager.battery_level;
    }
}
