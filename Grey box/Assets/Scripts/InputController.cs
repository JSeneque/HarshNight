using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    public float radius = 10.0f;

    public AudioClip choppingSound;
    public AudioSource source;

    private Inventory inventory;
    private GameObject player;
    private GameObject campFire;

    void Awake()
    {
        
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        campFire = GameObject.FindGameObjectWithTag("Campfire");
        inventory = player.GetComponent<Inventory>();
        source.clip = choppingSound;
    }
    // Update is called once per frame
    void Update ()
    {
		
        if (Input.GetKeyUp("e"))
        {
          
            // Use OverlapSphrere around the player to determine which game objects
            // nearby to interact with
            Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, radius);

            foreach(Collider col in hitColliders)
            {
                // this feels silly to dictate each object we can interactive with. 
                // Feel very wrong but going with it for now

                // if the player is near the campfire, 
                if (col.gameObject.tag == "Campfire")
                {
                    // check if there is any firewood in the inventory
                    for (int i = 0; i < inventory.slots.Length; i++)
                    {
                        // check if the slot has something
                        if (inventory.isFull[i] == true)
                        {
                            print("Slot " + i + " has something!");
                            // determine the itemButton in inventory

                            GameObject child = inventory.slots[i].gameObject.transform.GetChild(0).gameObject;

                            // if the item is a firewood then add to campfire
                            if (child.tag == "Firewood")
                            {
                                // empty slot
                                Destroy(child);
                                inventory.isFull[i] = false;
                                print("Destroy firewood from slot " + i);
                                // react campfire
                                campFire.GetComponent<CampFire>().AddFirewood();
                                break;
                            }

                            // if the item is a piece of raw meat, cook it
                            if (child.tag == "MeatRaw")
                            {
                                // 1. change the button to meat cooked
                                //Destroy(child);
                                //inventory.isFull[i] = false;
                                print("Cooked the meat in slot " + i);
                                
                                break;
                            }

                        }
                    }
                }

                // if the player is near a tree, start chopping
                if (col.gameObject.tag == "Tree")
                {
                    //source.PlayOneShot(choppingSound);
                    print("chopping sound");
                    source.Play();
                    col.gameObject.GetComponent<Tree2>().ChopMe();
                }
            }

        }
	}
}
