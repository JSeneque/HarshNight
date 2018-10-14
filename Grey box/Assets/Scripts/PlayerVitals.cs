using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVitals : MonoBehaviour {

    [System.Serializable]
    public class Health
    {
        public float startHealth = 100.0f;
        public float reduceHealthAmount = 1.0f;
        public float intervals = 5.0f;
        public Color goodHealthColour = Color.green;
        public Color midHealthColour = Color.yellow;
        public float midHealthAmount = 0.6f;
        public Color lowHealthColour = Color.red;
        public float lowHealthAmount = 0.3f;
        public Image healthBar;
    }
    public Health health;

    [System.Serializable]
    public class Heat
    {
        public float startHeat = 100.0f;
        public float reduceHeatAmount = 1.0f;
        public float intervals = 5.0f;
        public Color goodHeatColour = Color.green;
        public Color midHeatColour = Color.yellow;
        public float midHeatAmount = 0.6f;
        public Color lowHeatColour = Color.red;
        public float lowHeatAmount = 0.3f;
        public Image heatBar;
    }
    public Heat heat;

    [HideInInspector]
    private float initialHealth;
    private float initialHeat;
    private float healthSteps;
    private float heatSteps;

    // Use this for initialization
    void Start () {
        initialHealth = health.startHealth;
        healthSteps = health.intervals;
        initialHeat = heat.startHeat;
        heatSteps = heat.intervals;
    }
	
	// Update is called once per frame
	void Update () {

        // changes to health
        healthSteps -= Time.deltaTime;

        if (healthSteps <= 0)
        {
            healthSteps = health.intervals;
            initialHealth -= health.reduceHealthAmount;
            health.healthBar.fillAmount = initialHealth / health.startHealth;
        }

        // check the health and change colour of bar
        CheckHealth();

        // clamp health to zero
        if (initialHealth <= 0)
            initialHealth = 0;

        //changes to heat
        heatSteps -= Time.deltaTime;

        if (heatSteps <= 0)
        {
            heatSteps = heat.intervals;
            initialHeat -= heat.reduceHeatAmount;
            heat.heatBar.fillAmount = initialHeat / heat.startHeat;
        }

        // check the heat and change colour of bar
        CheckHeat();

        // clamp health to zero
        if (initialHeat <= 0)
            initialHeat = 0;


    }

    void CheckHealth()
    {
        float healthCheck = initialHealth / health.startHealth;

        if(healthCheck >= health.midHealthAmount)
        {
            health.healthBar.color = health.goodHealthColour;
        }
        if (healthCheck < health.midHealthAmount)
        {
            health.healthBar.color = health.midHealthColour;
        }
        if (healthCheck < health.lowHealthAmount)
        {
            health.healthBar.color = health.lowHealthColour;
        }
    }

    void CheckHeat()
    {
        float heatCheck = initialHeat / heat.startHeat;

        if (heatCheck >= heat.midHeatAmount)
        {
            heat.heatBar.color = heat.goodHeatColour;
        }
        if (heatCheck < heat.midHeatAmount)
        {
            heat.heatBar.color = heat.midHeatColour;
        }
        if (heatCheck < heat.lowHeatAmount)
        {
            heat.heatBar.color = heat.lowHeatColour;
        }
    }
}
