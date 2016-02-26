using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartingPoint;
    public PlayerControl player;
    private Vector3 playerStartPoint;
    private ScoreManager manager;
    private PlatformDestroyer[] platformListToBeDestroyed;
    public DeathBehaviour deathMenu;

    // Use this for initialization
    void Start() {
        platformStartingPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;
        manager = FindObjectOfType<ScoreManager>();

    }

    // Update is called once per frame
    void Update() {

    }

    public void Restart() {
        player.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(true);
        //StartCoroutine("RestartGameCo");
 
    }

    public void Reset()
    {
        deathMenu.gameObject.SetActive(false);
        platformListToBeDestroyed = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformListToBeDestroyed.Length; i++) {
            platformListToBeDestroyed[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartingPoint;
        player.gameObject.SetActive(true);
        manager.score = 0;
        manager.isAlive = true;
    }
    /*
    public IEnumerator RestartGameCo()
    {

        /*player.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        platformListToBeDestroyed = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformListToBeDestroyed.Length; i++)
        {
            platformListToBeDestroyed[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartingPoint;
        player.gameObject.SetActive(true);
        manager.score = 0;
        manager.isAlive = true;

    }*/
}
