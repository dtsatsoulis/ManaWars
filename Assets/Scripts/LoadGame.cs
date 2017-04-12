﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadMainGame()
    {
        SceneManager.LoadScene(1);
    }

	public void LoadControls()
	{
		//SceneManager.LoadScene(1);
		SceneManager.LoadScene(3);
	}

    public void ExitGame()
    {
        Application.Quit();
    }
}
