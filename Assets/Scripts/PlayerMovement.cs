using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runningSpeed = 20.0f;
    public float sideSpeed = 6.0f;
    public float jumpForce = 4.0f;
    private bool hasJumped = false;
    private float jumpTimer;
    System.Random random = new System.Random();
    public GameObject wall;
    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Rakt fram, vänster och höger justering med A och D
        transform.Translate(Vector3.forward * Time.deltaTime * runningSpeed);
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed);
            //body.velocity = Vector3.forward * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * sideSpeed);
        }

        // 90 graders sväng med pilar
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0, 90, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -90, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && hasJumped is false)
        {
            hasJumped = true;
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (hasJumped is true)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer > 0.2)
            {
                hasJumped = false;
                jumpTimer = 0;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            transform.Rotate(0, 90, 0);
            other.isTrigger = false;
        }
        Debug.Log("collision");
    }
}
