// Script for Player health bar at the top of the game screen.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;

public class HealthTotal : MonoBehaviour
{

    Text txt;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Player: " + GetComponent<PlayerCharacter>().getHealth();
    }

    // Update is called once per frame
    public void Update()
    {
        txt.text = "Player: " + GetComponent<PlayerCharacter>().getHealth();
    }
}