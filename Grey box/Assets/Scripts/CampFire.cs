using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{

    public float health = 0.5f;
    public float lowerFlameEveryXSec = 5.0f;
    public float smokeSize = 0.0f;
    public float flameSize = 0.3f;
    public float maxSmokeSize = 3.0f;
    public float volume;
    public float warmthZoneModifier = 0.5f;

    // make true if you do not want the health to lower over time
    public bool disableHealth = false;

    private GameObject flame;
    private GameObject smoke;
    private ParticleSystem flamePs;
    private ParticleSystem smokePs;
    private bool lowerSmoke;
    private float steps;
    private AudioSource audioSource;

    // sphere collider acting as the warmth zone 
    private SphereCollider warmthZone;

    // Use this for initialization
    void Start()
    {
        flame = gameObject.transform.Find("Flame").gameObject;
        smoke = gameObject.transform.Find("Smoke").gameObject;
        flamePs = flame.GetComponent<ParticleSystem>();
        smokePs = smoke.GetComponent<ParticleSystem>();
        //smoke.particleSystem.
        steps = lowerFlameEveryXSec;
        lowerSmoke = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
        warmthZone = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!disableHealth)
        {
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

            // adjust the camp fire sound based on the campfire health
            volume = health / 12.0f;
            audioSource.volume = volume;

            // adjust the warmth zone
            warmthZone.radius = health + warmthZoneModifier;

            // if fire is out and smoke is at it's highest,
            // time to lower the smoke intensity 
            if (health == 0 && !lowerSmoke)
            {
                lowerSmoke = true;
            }

            var main = flamePs.main;
            main.startSize = health;
        }


    }

    public void AddFirewood()
    {
        health += 0.5f;
        smokeSize = 0.0f;
        lowerSmoke = false;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    // check if player has enter the warmth zone
    //    if (other.tag == "Player")
    //    {
    //        Debug.Log("Player has enter the warmth zone");
    //        // add warmth to player

    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        // check if player has enter the warmth zone
        if (other.tag == "Player")
        {
            Debug.Log("Player has enter the warmth zone");
            // add warmth to player
            other.GetComponent<PlayerVitals>().IncreaseWarmth(5.0f);
        }
    }

}
