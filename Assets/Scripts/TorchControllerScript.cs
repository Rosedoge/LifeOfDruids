using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControllerScript : MonoBehaviour {


    public List<TorchScript> torches;

    public GameObject[] Bridge;
    bool AllTorchesLit = false;

	// Use this for initialization
	void Start () {
        foreach (GameObject bridge in Bridge)
        {
            bridge.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!AllTorchesLit)
        {
            foreach(TorchScript torch in torches)
            {
                if (torch.IsLit)
                {
                    torches.Remove(torch);
                }
            }
            if(torches.Count == 0)
            {
                AllTorchesLit = true;
                BuildBridge();
            }
        }
	}

    void BuildBridge()
    {
        foreach(GameObject bridge in Bridge)
        {
            bridge.SetActive(true);
        }
    }
}
