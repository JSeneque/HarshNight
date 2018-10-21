using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rabbit : MonoBehaviour {

    private NavMeshAgent _agent;

    public GameObject Player;

    public float PlayerDistanceRun = 4.0f;

	// Use this for initialization
	void Start () {
        _agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

        // get the distance from the player
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        //Debug.Log("Distance: " + distance);

        // if the player is too close, runaway
        if (distance < PlayerDistanceRun)
        {
            // work out the vector from the player to this object
            Vector3 directionToPlayer = transform.position - Player.transform.position;

            // move this object in that direction away
            Vector3 newPos = transform.position + directionToPlayer;

            _agent.SetDestination(newPos);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           Destroy(gameObject);
        }
    }
}
