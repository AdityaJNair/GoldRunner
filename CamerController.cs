using UnityEngine;
using System.Collections;

public class CamerController : MonoBehaviour {

    //The Class Object of PlayerControl - the player
    public PlayerControl runner;

    //The last known position of the player
    private Vector3 lastPlayerPosition;
    private float distanceToMove;

	// Use this for initialization
	void Start () {
        
        //Since there is a single player, find that Object that is type "PlayerControl"
        runner = FindObjectOfType<PlayerControl>();
        
        //set last known position
        lastPlayerPosition = runner.transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        //The distance that the player has moved to from the last known position
        distanceToMove = runner.transform.position.x - lastPlayerPosition.x;

        //The camera position set to the current position + the distance reqiired to move with the same y/z movement
        this.transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        
        //set the last known position of the player as the players current position
        lastPlayerPosition = runner.transform.position;

	
	}
}
