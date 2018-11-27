using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireRemoval : MonoBehaviour {

    public GameObject campfire1;
    public GameObject campfire2;
    public bool tutorialMode;

    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // disable campfire
            campfire1.SetActive(false);

            // enable campfire
            campfire2.SetActive(true);
            
        }

        if (!tutorialMode)
        {
            gm.SetTutorialMode(tutorialMode);
        }
    }
}
