using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedMeatItem : MonoBehaviour {

    public float healthIncrease = 20.0f;

    private PlayerVitals playerVitals;
    private GameManager gameManager;
    private Inventory inventory;
    private AudioSource boulderSound;

    private void Start()
    {
        playerVitals = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerVitals>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        boulderSound = GameObject.Find("Exit02").GetComponent<AudioSource>();
    }


    // handles which events to process depending on the item clicked
    // on in the inventory
    public void Use()
    {
        // increase the player's health
        playerVitals.IncreaseHealth(healthIncrease);

        // remove the meat from the 
        Destroy(this.gameObject);

        // if in tutorial mode, send event
        if (gameManager.IsTutorialMode())
        {
            EventManager.TriggerEvent("Exit02");

            // play the sound
            boulderSound.Play();
        }
    }
}
