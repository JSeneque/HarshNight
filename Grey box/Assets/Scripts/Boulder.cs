using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {
    private Animator animator;
    // Use this for initialization

    

    private void Awake()
    {
        EventManager.StartListening("LowerBoulder1", Lower);
    }

    void Start () {
        animator = GetComponent<Animator>();
	}
	
	void Lower()
    {
        // play sound
        animator.SetBool("LowerBoulder", true);
    }
}
