using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour {
    public float healthIncrease = 20.0f;
    private GameObject player;
    private GameObject gameManager;
    private Inventory inventory;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
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
