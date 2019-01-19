/*
Author: SIMON AYTES
Creation Date: 2018-03-24
Modification Date: 2018-03-24
Purpose: This script, when added to Unity, will create a property of the object (butto/trigger/etc.) that will result in the loading of a new scene. You can use this by adding it as a component and -->
dragging the initial scene and the desired scene into the component heirarchy of the object.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	public void LoadScene(string name)
	{
		Debug.Log("Level load requested for:" +name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest()
	{
		Debug.Log("I want to quit.");
		Application.Quit();
	} 
}