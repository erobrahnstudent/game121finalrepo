using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRespawn : MonoBehaviour {
    public Transform spawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = spawn.position;
        }
    }
}
