using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCaller : MonoBehaviour {
    public bool shouldDestroy = true;

    private void OnTriggerEnter(Collider other)
    {
        // check if the player enter the trigger area
        if(other.tag == "Player")
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
            
            if (shouldDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}
