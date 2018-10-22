using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rabbit : MonoBehaviour {
    // navmesh agent
    private NavMeshAgent _agent;

    // player prefab
    public GameObject Player;

    // the distance before the rabbit starts to flee
    public float PlayerDistanceRun = 4.0f;

    // the prefab for the raw meat
    public GameObject rawMeat;
    public float untouchable = 1.0f;

	// Use this for initialization
	void Start () {
        _agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
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
        // when the player touches the rabbit, destroy the rabbit
        if (collision.gameObject.CompareTag("Player"))
        {
            // distroy rabbit
            Destroy(gameObject);

            // drop the raw meat where the rabbit was
            // but first when it first appears, allow the player to pass through
            // and not collect it for a little while then make it collideable

            //StartCoroutine(CantTouchMeat(untouchable));
            Instantiate(rawMeat, this.gameObject.transform.position, Quaternion.identity);
        }
    }

    //IEnumerator CantTouchMeat(float time)
    //{
    //    yield return new WaitForSeconds(time);

    //    BoxCollider collider;

    //    collider = rawMeat.GetComponent<BoxCollider>();
    //    collider.enabled = false;
    //    
    //}
}
