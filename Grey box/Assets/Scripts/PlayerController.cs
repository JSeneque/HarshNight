using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    //private Animator anim;
    //public NavMeshAgent navMeshAgent;
    //public bool isWalking;

    //private CharacterController _controller;

    //public float movementSpeed;

    //void Start()
    //{
    //    //_controller = GetComponent<CharacterController>();
    //    anim = GetComponent<Animator>();
    //    navMeshAgent = GetComponent<NavMeshAgent>();
    //}

    //void Update()
    //{
    //    //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //    //_controller.Move(move * Time.deltaTime * movementSpeed);
    //    //if (move != Vector3.zero)
    //    //    transform.forward = move;
    //    //if(navMeshAgent.velocity != Vector3.zero)
    //    //{
    //    //    isWalking = true;
    //    //} else
    //    //{
    //    //    isWalking = false;
    //    //}

    //    var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
    //    var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

    //    transform.Rotate(0, x, 0);
    //    transform.Translate(0, 0, z);

    //    anim.SetBool("IsWalking", isWalking);

    //}
    public float speed;

    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
}
