using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public string playGame;


    public void Play()
    {
        Application.LoadLevel(playGame);
        
    }

    public void ChangeMap()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }

}
