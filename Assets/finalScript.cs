using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalScript : MonoBehaviour {
    PlayerInput p;
    public GameObject g;
	// Use this for initialization
	void Start () {
        p = FindObjectOfType<PlayerInput>();
	}
	
	// Update is called once per frame
	void Update () {
		if (g.transform.childCount == 0)
        {
            p.enabled = false;
            GetComponent<rotatingCam>().enabled = true;
            this.enabled = false;
        }
	}
}
