using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour {

    public float moveSpeed = 3.0f;
    public int moving = 0; // 1 = right, 2 = left
    public bool lastMove = false; // false == left, true == right

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (moving == 1)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (moving == 2)
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
	}

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (lastMove == false)
            {
                moving = 1;
                lastMove = true;
            }
            else
            {
                moving = 2;
                lastMove = false;
            }
        }
    }

    public void stop()
    {
        moving = 0;
    }
}
