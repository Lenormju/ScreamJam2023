using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
       
	public static Slider _battery_level;
    public static GameObject _player;

	private static GameManager _instance;
	public static GameManager Instance {
    		get {
	        	if (_instance == null) {
		            	GameObject go = new GameObject("GameManager");
		            	go.AddComponent<GameManager>();
	        	}
	        	return _instance;
	    	}
	    	set {
	        	_instance = value;
	    	}
	}

    private void Start()
    {
        GameObject battery_level_obj = GameObject.Find("BatteryLevel");
		_battery_level = battery_level_obj.GetComponent<Slider>();
		
        _player = GameObject.Find("player");
    }
}