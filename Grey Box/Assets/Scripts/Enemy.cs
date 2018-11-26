using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed = 3.0f;
    public float pursueDistance = 5.0f;

    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}

    public void TakeDamage(int amount)
    {
        health -= amount;

        // check if enemy is dead
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
       if (Vector3.Distance(transform.position, player.position) < pursueDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
