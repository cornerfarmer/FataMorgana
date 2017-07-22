using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    GetComponent<Text>().text = "Health: " + (int)Game.health + "\nThirst: " + (int)Game.thirst + "\nStamina: " + (int)Game.stamina;
	    
    }
}
