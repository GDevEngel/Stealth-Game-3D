using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScreen");
        Debug.Log("start game");
    }

    public void Quit()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
}
