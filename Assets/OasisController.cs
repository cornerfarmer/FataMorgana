using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OasisController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter()
    {
        Controller.isAbleToDrink = true;
    }

    void OnTriggerExit()
    {
        Controller.isAbleToDrink = false;
    }
}
