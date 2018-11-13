using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    private Animator anim;
    public NavMeshAgent navMeshAgent;
    public bool isWalking;

    //private CharacterController _controller;

    //public float movementSpeed;

    void Start()
    {
        //_controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //_controller.Move(move * Time.deltaTime * movementSpeed);
        //if (move != Vector3.zero)
        //    transform.forward = move;
        if(navMeshAgent.velocity != Vector3.zero)
        {
            isWalking = true;
        } else
        {
            isWalking = false;
        }

        anim.SetBool("IsWalking", isWalking);

    }
}
