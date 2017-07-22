using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static float health;
    public static float stamina;
    public static float thirst;
    public static bool isRunning;
    public GameObject PanelText;

    // Use this for initialization
    void Start ()
    {
        thirst = 100;
        health = 100;
        stamina = 100;
    }
	
	// Update is called once per frame
	void Update () {
	    stamina = Mathf.Min(100, stamina + 1 * Time.deltaTime);

        if (thirst < 20)
            health = Mathf.Max(0, health - 1 * Time.deltaTime);

	    thirst = Mathf.Max(0, thirst - 1 * Time.deltaTime);

	    if (health <= 0)
	        Die();

	    if (GetComponent<TerrainController>().ReachedGreenLand())
	        Win();
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
    }

    public static void DecreaseStaminaForWalk()
    {
        stamina = Mathf.Max(0, stamina - 1 * Time.deltaTime);
    }

    public static void DecreaseStaminaForRun()
    {
        stamina = Mathf.Max(0, stamina - 10 * Time.deltaTime);
        thirst = Mathf.Max(0, thirst - 1 * Time.deltaTime);
    }

}
