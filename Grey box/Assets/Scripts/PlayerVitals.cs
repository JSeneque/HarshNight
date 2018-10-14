using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVitals : MonoBehaviour {

    [Header("Player Health Settings")]
    public float startHealth = 100.0f;
    public float reduceHealthAmount = 1.0f;
    public float healthIntervals = 5.0f;
    public Color goodHealthColour = Color.green;
    public Color midHealthColour = Color.yellow;
    public float midHealthAmount = 0.6f;
    public Color lowHealthColour = Color.red;
    public float lowHealthAmount = 0.3f;
    public Image healthBar;

    [HideInInspector]
    private float health;
    private float steps;

    // Use this for initialization
    void Start () {
        health = startHealth;
        steps = healthIntervals;
    }
	
	// Update is called once per frame
	void Update () {
        steps -= Time.deltaTime;

        if (steps <= 0)
        {
            steps = healthIntervals;
            health -= reduceHealthAmount;
            healthBar.fillAmount = health / startHealth;
        }

        // check the health and change colour of bar
        CheckHealth();

        // clamp health to zero
        if (health <= 0)
            health = 0;


    }

    void CheckHealth()
    {
        float healthCheck = health / startHealth;

        if(healthCheck >= midHealthAmount)
        {
            healthBar.color = goodHealthColour;
        }
        if (healthCheck < midHealthAmount)
        {
            healthBar.color = midHealthColour;
        }
        if (healthCheck < lowHealthAmount)
        {
            healthBar.color = lowHealthColour;
        }

    }
}
