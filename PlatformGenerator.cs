using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {
    
    //The point of the platformGenerationPoint under the Main Camera position.
    public Transform generationPoint;
    public GameObject thePlatform;

    //the jump distance of max and min
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    private float distanceBetween;

    //Selects which platform from array index
    private int platformSelector;

    //An array of all platform widths that will be set from the objectPoolArray objects contained. Each object pool contains a gameobject from which a width(x) is used.
    private float[] platformWidths;
    public ObjectPool[] theObjectPoolArray;


    //Jumping Additions
    private float minHeight;
    private float maxHeight;
    //Am Object in the game that has a transform
    public Transform maxHeightPoint;
    public float maxHeightChanged;
    private float heightChanged;

    private CoinGenerator theCoin;


    // Use this for initialization.
    void Start () {

        //Set the platformWidths array with the same length as the objectPooledArray to match index values.
        platformWidths = new float[theObjectPoolArray.Length];
        //Iterate through and give each index value of the platformWidths array the corresponding width(x) value
        for (int i = 0; i < theObjectPoolArray.Length; i++)
        {
            //set widths
            platformWidths[i] = theObjectPoolArray[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
            print("i= " + platformWidths[i]);
        }

        //set the min/max height we would like to be position the platforms
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        theCoin = FindObjectOfType<CoinGenerator>();
	
	}
	
	// Update is called once per frame
    // This is for the point that moves to the end of the next platform section. We want this to be at the middle of every platform other than the first
	void Update () {

        //The position of the current object (PlatformGenerator) is behind the generation point. Since PlatformGenerationPoint follows the Main Camera which follows
        //the player then it will always be ahead of the PlatformGenerator.
        if(transform.position.x < generationPoint.position.x)
        {

            //create a random distance between min/max
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            //Select a random platform from 0 to size of the array
            platformSelector = Random.Range(0, theObjectPoolArray.Length);

            //Moving the GenreationPoint to another Y value so that it can spawm platforms at that position. +- the height we can jump
            heightChanged = transform.position.y + Random.Range(maxHeightChanged,-maxHeightChanged);
            
            //
            if(heightChanged> maxHeight)
            {
                heightChanged = maxHeight;
            } else if (heightChanged < minHeight)
            {
                heightChanged = minHeight;
            }
            

            //The original position of the PlatformGenerator is at the end of the first platform. Set the next position = the end position + the random jump width +
            //the next platform selected's width / 2 so it would be exactly halfway of the next platform made.
            transform.position = new Vector3(transform.position.x + distanceBetween + platformWidths[platformSelector]/2, heightChanged, transform.position.z);
            print(transform.position);

            //From the existing pool of objects, the new platform will be given a tranform position/rotation and set true
            GameObject newPlatform = theObjectPoolArray[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            print(newPlatform.transform.position);
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0, 50) % 5 == 0)
            {
                theCoin.coinSpawner(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z));
            }
           

            //Set the position of the PlatformGenerator + halfway of the current position (which was halfway of the block) to the end of the platform, since we are 
            //adding the second half of the platform to the position.x value
            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector]/2, transform.position.y, transform.position.z);
        }
	
	}
}
