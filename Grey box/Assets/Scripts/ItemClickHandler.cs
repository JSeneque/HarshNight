using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour {
    public float healthIncrease = 20.0f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnItemClicked()
    {
        if (gameObject.tag == "MeatCooked")
        {
            // increase the player's health
            player.GetComponent<PlayerVitals>().IncreaseHealth(healthIncrease);

            // remove the meat from the 
            Destroy(this.gameObject);

        }
    }
}
