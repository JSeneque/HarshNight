using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
    public int speed = 20;
    public int logs = 4;
    public int destroyTreeDelay = 5;
    public int treeFallDelay = 4;
    public GameObject highlighter;

    // stores the prefab for the firewood
    public GameObject log;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        // stops the tree from being pushed by player
        rb.isKinematic = true;
	}


    IEnumerator DestroyTree(float time)
    {
        yield return new WaitForSeconds(time);

        // destory this tree
        Destroy(this.gameObject);

        // the logs are to be dropped
        Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        for (int i = 0; i < logs; i++)
            Instantiate(log, this.gameObject.transform.position + new Vector3(0, 0, i ) + position , Quaternion.identity);

    }

    public void ChopMe()
    {
        StartCoroutine(TreeFall(treeFallDelay));
    }

    IEnumerator TreeFall(float time)
    {
        yield return new WaitForSeconds(time);

        // remove highlighting object
        Destroy(highlighter);

        // allow force applied to tree to fall
        rb.isKinematic = false;

        // pushing force
        rb.AddForce(transform.forward * speed);

        // delay before destorying tree
        StartCoroutine(DestroyTree(destroyTreeDelay));
    }
}
