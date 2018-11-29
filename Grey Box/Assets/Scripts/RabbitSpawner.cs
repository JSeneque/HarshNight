using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawner : MonoBehaviour {
    public Transform spawnPoint;
    public GameObject rabbit;
    public float interval = 120.0f;
    public float step;

    private GameManager gm;

	// Use this for initialization
	void Start () {
        step = interval;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

    // Update is called once per frame
    void Update()
    {
        step -= Time.deltaTime;

        // decrease health over time
        if (step <= 0)
        {
            step = interval;
            SpawnRabbit();
        }
    }

    void SpawnRabbit()
    {
        // check the rabbit capacity
        if (gm.CheckCanSpawnRabbit())
        {
            // instantiate a rabbit  at the spawning point
            Instantiate(rabbit, spawnPoint.position, Quaternion.identity);
            gm.AddRabbit();
        }
        
    }
}

