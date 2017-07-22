using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animation animation;
    private float lastTime;
    public GameObject footPrint;
    public GameObject leftFoot;
    public GameObject rightFoot;

    // Use this for initialization
    void Start ()
	{
	    animation = GetComponent<Animation>();
	    lastTime = 0.9f;
	}

    void SpawnFootprint(bool left)
    {
        GameObject foot = left ? leftFoot : rightFoot;

        int layer_mask = LayerMask.GetMask("Terrain");
        RaycastHit hit;
        Physics.Raycast(new Ray(foot.transform.position + foot.transform.up, foot.transform.up * -1), out hit, 10, layer_mask);
        GameObject newFootPrint = Instantiate(footPrint, hit.point, Quaternion.LookRotation(hit.normal, Quaternion.Euler(90, 0, 0) * hit.normal));

        newFootPrint.transform.Rotate(Vector3.right, 90);
        newFootPrint.transform.Rotate(Vector3.up, foot.transform.rotation.eulerAngles.y);
        newFootPrint.transform.Translate(new Vector3(0, 0.01f, 0));
    }

	
	// Update is called once per frame
	void Update () {
	    if (Input.GetAxis("Vertical") != 0)
	    {
            if (Input.GetKey(KeyCode.LeftShift))
	            animation.Play("run");
            else
                animation.Play("walk");
	        if (lastTime > animation["walk"].normalizedTime)
	            lastTime--;

	        if (lastTime < 0 && animation["walk"].normalizedTime >= 0)
	            SpawnFootprint(false);
            else if (lastTime < 0.5f && animation["walk"].normalizedTime >= 0.5f)
                SpawnFootprint(true);

            lastTime = animation["walk"].normalizedTime;
	    }
	    else
	    {
	        animation.Play("idle");
        }
	}
}
