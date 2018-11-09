using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree2 : MonoBehaviour {
    public int health = 5;
    public int speed = 8;
    public int logs = 4;
    public int destroyTreeDelay = 5;
    public int treeFallDelay = 4;

    public GameObject log;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
            StartCoroutine(TreeFall(treeFallDelay));
        }
	}

    IEnumerator DestroyTree(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
        Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        for (int i = 0; i < logs; i++)
            Instantiate(log, this.gameObject.transform.position + new Vector3(0, 0, i ) + position , Quaternion.identity);

    }

    public void ChopMe()
    {
        health--;
        if (health < 0)
            health = 0;
    }

    IEnumerator TreeFall(float time)
    {
        yield return new WaitForSeconds(time);

        // remove highlighting object
        GameObject child = gameObject.transform.GetChild(0).gameObject;
        Destroy(child);

        rb.isKinematic = false;
        rb.AddForce(transform.forward * speed);
        StartCoroutine(DestroyTree(destroyTreeDelay));
    }
}
