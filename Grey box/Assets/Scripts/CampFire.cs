using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour {

    public float health = 0.5f;
    public float lowerFlameEveryXSec = 5.0f;

    private GameObject flame;
    private GameObject smoke;
    private ParticleSystem flamePs;
    private float steps;

    // Use this for initialization
    void Start () {
        flame = gameObject.transform.Find("Flame").gameObject;
        smoke = gameObject.transform.Find("Smoke").gameObject;
        flamePs = flame.GetComponent<ParticleSystem>();
        //smoke.particleSystem.
        steps = lowerFlameEveryXSec;
    }
	
	// Update is called once per frame
	void Update () {
        steps -= Time.deltaTime;

        if (steps <= 0)
        {
            steps = lowerFlameEveryXSec;
            health -= 0.1f;


            //ParticleSystem ps = GetComponent<ParticleSystem>();
            
            //main.startLifetime = 2.0f;
        }

        var main = flamePs.main;
        main.startSize = health;
    }

    public void AddFirewood()
    {
        health += 0.5f;
    }
}
