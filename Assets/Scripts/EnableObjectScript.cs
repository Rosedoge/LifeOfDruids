using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectScript : MonoBehaviour {


    public GameObject Rotator = null;
    public GameObject triggerObject;
	// Use this for initialization
	void Start () {
        if (triggerObject.activeSelf)
        {
            triggerObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            if(Rotator != null)
            {
                Destroy(Rotator);
            }
            triggerObject.SetActive(true);
        }
    }
}
