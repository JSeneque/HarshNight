using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
    public int noOfChopsForWood = 3;
    public int noOfWoodBeforeFell = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Axe") {
            noOfChopsForWood--;
        }
    }

    void resetChops()
    {
        noOfChopsForWood = 3;   //remove this hardcoded value
        noOfWoodBeforeFell--;
        if (noOfWoodBeforeFell <= 0) {
            //make the tree fall
        }
    }
}
