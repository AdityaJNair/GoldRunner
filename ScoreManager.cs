using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    public float score;
    public float highscore;
    public PlayerControl player;
    public float playerCurrentXPos;
    public float scorePerSecond;
    public bool isAlive;

	// Use this for initialization
	void Start () {
        playerCurrentXPos = player.transform.position.x;
        if(PlayerPrefs.HasKey("High Score"))
        {
            highscore = PlayerPrefs.GetFloat("High Score");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (isAlive)
        {
            if (player.transform.position.x != playerCurrentXPos)
            {
                score += scorePerSecond * Time.deltaTime;
            }
        }


        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("High Score", highscore);
        }

        scoreText.text = "Score: " + score.ToString("0");
        highScoreText.text = "High Score: " + highscore.ToString("0");
        playerCurrentXPos = player.transform.position.x;
    }

    public void CoinTrigger(int valueOfCoin)
    {
        score += valueOfCoin;
    }
}
