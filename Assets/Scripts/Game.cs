using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static float health;
    public static float thirst;
    public static bool isRunning;
    public GameObject PanelText;
    public static float healthDecreaseSpeed = 1;
    public static float thirstDecreaseSpeed = 1.5f;

    // Use this for initialization
    void Start ()
    {
        thirst = 100;
        health = 100;
        isRunning = true;
    }
	
	// Update is called once per frame
	void Update () {
	    if (Game.isRunning)
	    {

	        if (thirst <= 0)
	            health = Mathf.Max(0, health - healthDecreaseSpeed * Time.deltaTime);

	        thirst = Mathf.Max(0, thirst - thirstDecreaseSpeed * Time.deltaTime);

	        if (health <= 0)
	            Die();

	        if (GetComponent<TerrainController>().ReachedGreenLand())
	            Win();
	    }
	}

    void Die()
    {
        isRunning = false;
        PanelText.transform.parent.gameObject.SetActive(true);
        PanelText.GetComponent<Text>().text = "You died... alone...\nin the desert :(\n\nTry again!";
    }

    void Win()
    {
        isRunning = false;
        PanelText.transform.parent.gameObject.SetActive(true);
        PanelText.GetComponent<Text>().text = "You won!\n You found a way\nout of this desert! :)";
        GetComponent<MusicController>().PlayWinningSound();
    }
    
}
