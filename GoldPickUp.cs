using UnityEngine;
using System.Collections;

public class GoldPickUp : MonoBehaviour {

    public int value;
    public ScoreManager management;


	// Use this for initialization
	void Start () {
        management = FindObjectOfType<ScoreManager>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            management.CoinTrigger(value);
            gameObject.SetActive(false);
        }
    }
}
