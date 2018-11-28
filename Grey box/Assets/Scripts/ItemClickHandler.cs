using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour {
    public float healthIncrease = 20.0f;
    private GameObject player;
    private GameObject inventory;
    private GameObject gameManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }


    // handles which events to process depending on the item clicked
    // on in the inventory
    public void OnItemClicked()
    {
        // if cooked meat is clicked
        if (gameObject.tag == "MeatCooked")
        {
            // increase the player's health
            player.GetComponent<PlayerVitals>().IncreaseHealth(healthIncrease);

            // remove the meat from the 
            Destroy(this.gameObject);


            // need to work out which slot the meat was in to free it up.
            // as a quick fix, all invetory to check if there is no child
            Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                // check that the slot is marked as full
                if (inventory.isFull[i] == true)
                {
                    GameObject child = inventory.slots[i].gameObject.transform.GetChild(0).gameObject;

                    // if there is actually nothing in there, free it up
                    if (child == null)
                    {
                        inventory.isFull[i] = false;
                    }
                    break;
                }
            }

            // if in tutorial mode, send event
            if (gameManager.GetComponent<GameManager>().IsTutorialMode())
            {
                EventManager.TriggerEvent("Exit02");

                // find the boulder
                GameObject boulder = GameObject.Find("Exit02");

                // play the sound
                AudioSource audio = boulder.GetComponent<AudioSource>();
                audio.Play();
            }
        }
    }
}
