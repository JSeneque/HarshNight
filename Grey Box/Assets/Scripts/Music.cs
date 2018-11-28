using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    private static Music instance;

    private void Awake()
    {
        // check if there is aleady an instance of the muics
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } 
        else
        {
            Destroy(gameObject);
        }
    }
}
