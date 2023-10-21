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
        _battery_level.maxValue = 100;
        _battery_level.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (_battery_level.value > 0){
            _battery_level.value -= battery_consumption * Time.deltaTime;
        }
    }
}
