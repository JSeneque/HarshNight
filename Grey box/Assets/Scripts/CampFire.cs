using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour {

    public float health = 0.5f;
    public float lowerFlameEveryXSec = 5.0f;
    public float smokeSize = 0.0f;
    public float flameSize = 0.3f;
    public float maxSmokeSize = 3.0f;

    private GameObject flame;
    private GameObject smoke;
    private ParticleSystem flamePs;
    private ParticleSystem smokePs;
    private bool lowerSmoke;
    private float steps;

    // Use this for initialization
    void Start () {
        flame = gameObject.transform.Find("Flame").gameObject;
        smoke = gameObject.transform.Find("Smoke").gameObject;
        flamePs = flame.GetComponent<ParticleSystem>();
        smokePs = smoke.GetComponent<ParticleSystem>();
        //smoke.particleSystem.
        steps = lowerFlameEveryXSec;
        lowerSmoke = false;
    }
	
	// Update is called once per frame
	void Update () {
        steps -= Time.deltaTime;

        if (steps <= 0)
        {
            steps = lowerFlameEveryXSec;
            health -= 0.1f;

            if (health <= flameSize)
            {
                if (!lowerSmoke)
                    smokeSize += 1.0f;
                else 
                    smokeSize -= 0.5f;
            }
        }

        if (smokeSize <= 0)
            smokeSize = 0;

        // clamp health to zero
        if (smokeSize >= maxSmokeSize)
            smokeSize = maxSmokeSize;

        // the camp fire is getting low, start smoking
        var smokeMain = smokePs.main;
        smokeMain.startSize = smokeSize;

        
        // clamp health to zero
        if (health <= 0)
            health = 0;

        // if fire is out and smoke is at it's highest,
        // time to lower the smoke intensity 
        if (health == 0 && !lowerSmoke)
        {
            lowerSmoke = true;
        }

        var main = flamePs.main;
        main.startSize = health;
    }

    public void AddFirewood()
    {
        health += 0.5f;
        smokeSize = 0.0f;
        lowerSmoke = false;
    }
}
