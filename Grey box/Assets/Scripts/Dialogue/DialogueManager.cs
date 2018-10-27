using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    // UI Text
    //public Text nameText;
    public Text dialogueText;
    public Image continueButton;

    // animator
    //public Animator animator;

    // keep track of all the sentences in our current dialogue
    public Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
        dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, 0);
        continueButton.color = new Color(continueButton.color.r, continueButton.color.g, continueButton.color.b, 0);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //animator.SetBool("IsOnScreen", true);
        StartCoroutine(FadeTextToZeroAlpha(1f));

        // set the name
        // nameText.text = dialogue.name;

        // clear any sentences from previous conversation
        sentences.Clear();

        // load in the sentences
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        // check if there is no more sentences left in the queue
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // get the next sentence from queue
        string sentence = sentences.Dequeue();

        // in case the player decides to skip to the next sentence
        StopAllCoroutines();

        // display the sentence
        StartCoroutine(TypeSentence(sentence));
    }

    // type up the text character by character
    IEnumerator TypeSentence (string sentence)
    {
        // clear out any text
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            // delay a frame between each letter
            yield return null;
        }
    }

    void EndDialogue()
    {
        //animator.SetBool("IsOnScreen", false);
        //StartCoroutine(FadeTextToFullAlpha(1f, dialogueText));
        StartCoroutine(FadeTextToZeroAlpha(1f));
   
    }

    public IEnumerator FadeTextToFullAlpha(float t)
    {
        dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, 0);
        continueButton.color = new Color(continueButton.color.r, continueButton.color.g, continueButton.color.b, 0);

        while (dialogueText.color.a < 1.0f)
        {
            dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, dialogueText.color.a + (Time.deltaTime / t));
            continueButton.color = new Color(continueButton.color.r, continueButton.color.g, continueButton.color.b, continueButton.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t)
    {
        dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, 1);
        continueButton.color = new Color(continueButton.color.r, continueButton.color.g, continueButton.color.b, 1);
        while (dialogueText.color.a > 0.0f)
        {
            dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, dialogueText.color.a - (Time.deltaTime / t));
            continueButton.color = new Color(continueButton.color.r, continueButton.color.g, continueButton.color.b, continueButton.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

}

