using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndDoor : MonoBehaviour {

    public String scenetoload;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hello");
        if (collision.name.Contains("Player"))
        {
            SceneManager.LoadScene(scenetoload);
        }
    }
}
