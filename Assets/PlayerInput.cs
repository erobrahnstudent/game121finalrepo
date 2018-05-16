using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    CharacterController control;

    public bool SeekTargetSet;
    Vector3 target;
    public float satisfactionRadius = 1.0f;

    public float moveSpeed = 5.0f;
    public float rotateSpeed = 5.0f;

    // Use this for initialization
    void Start()
    {
        control = gameObject.GetComponent<CharacterController>();
        control.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 1000))
            {
                Debug.Log(hitInfo.collider.name + ", " + hitInfo.collider.tag);
                if (hitInfo.collider.tag == "Floor")
                {
                    Seek(hitInfo.point, true);
                }
            }

        }
        if (SeekTargetSet)
        {
            control.enabled = true;
            Vector3 moveDirection = target - transform.position;
            Vector3 rotateVector = Vector3.RotateTowards(transform.forward, moveDirection, rotateSpeed * Time.deltaTime, 0.0f);
            moveDirection.y = 0;
            control.transform.rotation = Quaternion.LookRotation(rotateVector);

            control.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
            if (Vector3.Distance(target, control.transform.position) < satisfactionRadius)
            {
                SeekTargetSet = false;
            }
            control.enabled = false;
        }
    }
    public void Seek(Vector3 position, bool arrive)
    {
        target = position;
        target.y = transform.position.y;
        SeekTargetSet = true;
    }
}
