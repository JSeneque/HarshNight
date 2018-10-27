using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour {
    private Slider bar;

    float timeTaken;

	// Use this for initialization
	void Start () {
        bar = GetComponent<Slider>();
        //bar.value = bar.maxValue;
	}

    // Update is called once per frame
    void Update()
    {
        //// record total time taken
        //timeTaken += Time.deltaTime;

        //// reduce bar 
        //bar.value = bar.maxValue - timeTaken;

        //if (bar.value < 0)
        //    bar.value = 0;

    }
}
