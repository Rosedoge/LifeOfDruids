using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCreatorScript : MonoBehaviour {

    public int min= 0, max = 40;
    [SerializeField]
    GameObject lavalObject;
	// Use this for initialization
	void Start () {
        InvokeRepeating("LaunchLava", 0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LaunchLava()
    {
        Vector2 loc = new Vector2(Random.Range(min, max),transform.position.y);

        GameObject temp = Instantiate(lavalObject, loc, transform.rotation);

    }
}
