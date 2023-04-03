using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    private Rigidbody myBody;

    public float walkSpeed = 3f;
    public float zSpeed = 1.5f;

    private float rotationY = -90f;
    private float rotationSpeed = 15f;
    void Start()
    {
        playerAnimation = GetComponentInChildren<PlayerAnimation>();
        myBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rotatePlayer();
    }
    private void FixedUpdate()
    {
        detectMovement();
        animatePlayerWalk();
    }
    // Update is called once per frame
    void detectMovement()
    {
        myBody.velocity = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walkSpeed), myBody.velocity.y, Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-zSpeed));
    }

    void rotatePlayer()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        }else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotationY), 0f);
        }
    }

    void animatePlayerWalk()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS)!=0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            playerAnimation.walk(true);
        }
        else
        {
            playerAnimation.walk(false);
        }
    }
}
