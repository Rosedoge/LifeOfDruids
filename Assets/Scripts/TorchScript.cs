﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour {

    public Sprite[] sprites;

    public bool lit = false;
	// Use this for initialization
	void Start () {
		if(lit == true)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            IsLit = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Fireball"))
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            IsLit = true;
        }
    }

    public bool IsLit
    {
        get
        {
            return lit;

        }
        set
        {

            lit = value;

        }
    }
}
