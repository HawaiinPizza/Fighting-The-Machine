using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log("Program is terminating.");
        Application.Quit();
    }

    // Add in the Scene Manager to go to the credit screen
    public void RunCredits()
    {
        Debug.Log("Rolling credits.");
        SceneManager.LoadScene(4);
    }
}
