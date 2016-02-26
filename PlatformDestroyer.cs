using UnityEngine;
using System.Collections;

/*
    Used in the platforms
    this. == refers to the platform
*/

public class PlatformDestroyer : MonoBehaviour {

    //The GameObject for the destructionPoint
    public GameObject platformDestructionPoint;


	// Use this for initialization
	void Start () {

        //GameObject.Find looks for the particular object that has the name "___"
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {

        //Since the camera is moving check the current position of the platform to see if it is behind the PlatformDestructionPoint if so we dont need it active
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            //Deactivates the gameObject
            gameObject.SetActive(false);
        }
	    

	}
}
