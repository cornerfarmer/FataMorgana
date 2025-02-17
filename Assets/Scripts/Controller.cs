﻿using System.Collections;
using System.Collections.Generic;
using ProceduralToolkit;
using ProceduralToolkit.Examples;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float WalkSpeed = 3;
    public float RunSpeed = 9;
    public float RotateSpeed = 100f;
    public TerrainController TerrainController;
    public static bool isWalking = false;
    public static bool isAbleToDrink = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Game.isRunning)
	    {
	        transform.Rotate(transform.up, Input.GetAxis("Horizontal") * RotateSpeed * Time.deltaTime);

	        if (Input.GetAxis("Vertical") != 0)
	        {
	            Vector3 dir = transform.forward;

	            int layer_mask = LayerMask.GetMask("Terrain");
	            RaycastHit hit;
	            Physics.Raycast(new Ray(transform.position + transform.up, transform.up * -1), out hit, 10, layer_mask);
	            dir.x += hit.normal.x * 0.5f;
	            dir.z += hit.normal.z * 0.5f;

	            float angle = Vector3.Angle(transform.forward, dir);
	            Vector3 cross = Vector3.Cross(transform.forward, dir);
	            if (cross.y < 0) angle = -angle;

	            transform.Rotate(transform.up, angle * 0.02f);

	            transform.position += Input.GetAxis("Vertical") * transform.forward *
	                                  (Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed) * Time.deltaTime;

	            isWalking = true;
	        }
	        else
	        {
	            isWalking = false;
	        }

	        float height =
	            LowPolyTerrainGenerator.GetHeightAtWorldPos(transform.position.x, transform.position.z,
	                TerrainController.config);
	        transform.position = new Vector3(transform.position.x, height, transform.position.z);

	        if (Input.GetKeyUp(KeyCode.F) && isAbleToDrink)
	        {
	            Game.thirst = 100;
	        }
	    }
	}
}
