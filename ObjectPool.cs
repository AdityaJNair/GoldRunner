using UnityEngine;
using System.Collections;
//REQUIRE GENERIC FROM COLLECTIONS TO USE LIST
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    //GameObject for the platform
    public GameObject pooledObject;

    //How many platforms to pool
    public int pooledAmount;
    
    //A list of all Platforms
    public List<GameObject> pooledObjectsList;


	// Use this for initialization
	void Start () {
        //initialise a new List
        pooledObjectsList = new List<GameObject>();

        //Iterate through how many we have pooled 
        for (int i = 0; i < pooledAmount; i++)
        {
            //For how many pooledAmount we give, create that many Platform of the type used and set as inactive.
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);

            //Add it to the overall list.
            pooledObjectsList.Add(obj);
        }
    }
	
    /*
        GetPooledObject interates through the pooledObjectsList and checks if a platform is inactive, if so we can use that particular object in the game.
        If not active and no more is there in the pool we can create another object, add it to the List, and return it to be used (while inactive)
    */
    public GameObject GetPooledObject()
    {

        //Iterate through the List
        for(int i = 0; i < pooledObjectsList.Count; i++)
        {

            //Check if inactive
            if (!pooledObjectsList[i].activeInHierarchy) 
            {
                return pooledObjectsList[i];
            }
        }

        //If not enough Objects left in the list add more to the List and retrun the new created platform.
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjectsList.Add(obj);
        return obj;
    }
}
