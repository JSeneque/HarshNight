using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warmth : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        // check if player has enter the warmth zone
        if (other.tag == "Player")
        {
            Debug.Log("Player has enter the warmth zone");
            // add warmth to player
            other.GetComponent<PlayerVitals>().IncreaseWarmth(5.0f);
        }
    }
}
