using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    public Dialogue dialogue;

    public void TriggerDialogue ()
    {
        // might be better to change this to a singleton
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
