using UnityEngine;
using System.Collections;

public class DeathBehaviour : MonoBehaviour {

    public string mainMenuLvl;

    public void Restart()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void BackToMainMenu()
    {
        Application.LoadLevel(mainMenuLvl);
    }
}
