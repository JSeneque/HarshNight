using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighting : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "Highlight")
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "Highlight")
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
}
