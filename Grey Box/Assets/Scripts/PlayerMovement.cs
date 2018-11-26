using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6.0f;                                      // the speed the player will move
    public float turnSpeed = 60.0f;                                 // the speed in which the player will turn
    public float turnSmoothing = 15.0f;                             // used to smooth out the turning

    private Vector3 movement;
    //private Vector3 turning;
    private Animator anim;
    private Rigidbody rb;

    private void Awake()
    {
        // get the componments
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // store input axes
        float lh = Input.GetAxisRaw("Horizontal");
        float lv = Input.GetAxisRaw("Vertical");

        Move(lh, lv);

        Animating(lh, lv);
    }

    private void Animating(float lh, float lv)
    {
        //throw new NotImplementedException();

        bool moving = lh != 0f || lv != 0f;

        anim.SetBool("IsWalking", moving);
    }

    private void Move(float lh, float lv)
    {
        // move the player
        movement.Set(lh, 0f, lv);

        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);

        if (lh != 0f || lv != 0f) {
            Rotating(lh, lv);
        }
    }

    void Rotating(float lh, float lv)
    {
        Vector3 targetDirection = new Vector3(lh, 0f, lv);

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, turnSmoothing * Time.deltaTime);

        rb.MoveRotation(newRotation);

    }


}
