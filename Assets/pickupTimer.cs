using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupTimer : MonoBehaviour {
    bool onTimer;
    bool done;
    public float time;
    float timer;

    float upTorque;
    float rightTorque;
    Rigidbody r;
	// Use this for initialization
	void Start () {
        r = GetComponent<Rigidbody>();
        upTorque = Random.Range(50, 200);
        rightTorque = Random.Range(50, 200);
    }
	
	// Update is called once per frame
	void Update () {
		if (onTimer && !done)
        {
            timer += Time.deltaTime;
            if (timer > time)
            {
                Destroy(this.gameObject);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !onTimer)
        {
            r.isKinematic = false;
            r.AddTorque(transform.right * rightTorque);
            r.AddTorque(transform.up * upTorque);
            r.AddForce(transform.up * 500);
            this.transform.position += new Vector3(0, 2, 0);
            onTimer = true;
        }
    }
}
