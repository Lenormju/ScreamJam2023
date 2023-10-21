using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
       
    public static player player;

	public static float battery_level;
	public static float battery_level_start = 100;

	public float battery_consumption = 10;

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

    void Start()
    {
		battery_level = 100;
		
        GameObject player_obj = GameObject.Find("player");
		player = player_obj.GetComponent<player>();
    }

	void Update()
	{
		if ( battery_level > 0)
		{
            battery_level -= battery_consumption * Time.deltaTime;
        }
		else
		{
			UnityEngine.Rendering.Universal.Light2D light =  player.smartphone_light.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
			light.intensity = 0;
		}
	}
}