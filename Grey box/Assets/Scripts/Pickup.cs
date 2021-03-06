﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private Inventory inventory;
    public GameObject itemButton;

	// Use this for initialization
	void Start () {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // add gameobject to a free inventory slot
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    // item can be added to the inventory
                    inventory.isFull[i] = true;
                    
                    // add the item button to the inventory slot
                    Instantiate(itemButton, inventory.slots[i].transform, false);

                    // get rid of the item in the game that was pickup
                    Destroy(gameObject);
                    break;
                }
            }
            //Destroy(gameObject);
        }
    }
}
