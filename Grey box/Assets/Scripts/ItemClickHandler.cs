using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour {
    public float healthIncrease = 20.0f;
    private GameObject player;
    private GameObject inventory;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
            GameObject inventory = GameObject.FindGameObjectWithTag("Inventory");
            
            // for each shild of inventory, does it have a child
            // player.GetComponent<Inventory>().
        }
    }
}
