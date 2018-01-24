using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("QuitGame", 10f);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    void QuitGame()
    {
        Application.Quit();
    }
}
