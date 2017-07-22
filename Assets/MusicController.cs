using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public AudioClip background1;
    public AudioClip background2;
    public AudioClip winning;
    public AudioClip wind;
    private AudioSource audioSource;
    private double timeSinceLastSound;


    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = wind;
        audioSource.PlayDelayed(5);
        timeSinceLastSound = 0;
    }
	
	// Update is called once per frame
	void Update () {

	    if (!audioSource.isPlaying)
	    {
	        if (timeSinceLastSound > 1)
	        {
	            audioSource.Stop();
                int rand = Random.Range(0, 4);
	            if (rand == 0)
	            {
	                audioSource.clip = background1;
	                audioSource.Play();
                }
                else if (rand == 1)
	            {
	                audioSource.clip = wind;
	                audioSource.Play();
                }
	            else if (rand == 2)
	            {
	                audioSource.clip = background2;
	                audioSource.Play();
	            }
	            timeSinceLastSound = 0;
	        }
            else
	            timeSinceLastSound += Time.deltaTime;
	    }
	}

    public void PlayWinningSound()
    {
        audioSource.clip = winning;
        audioSource.Play();
    }
}
