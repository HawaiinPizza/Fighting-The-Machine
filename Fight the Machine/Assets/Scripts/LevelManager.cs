using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LevelSwitcher()
    {
        SceneManager.LoadScene(2); // Change the value of "2" to route to the desired scene. This can be monitored / assigned in the build settings.
    }

}