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
        //public Image healthBar;
        public Slider healthBar;
        //public float currentHealth;
    }
    public Health health;
    

    [System.Serializable]
    public class Warmth
    {
        public float startWarmth = 100.0f;
        public float reduceWarmthAmount = 1.0f;
        public float intervals = 5.0f;
        public Color goodHeatColour = Color.green;
        public Color midHeatColour = Color.yellow;
        public float midHeatAmount = 0.6f;
        public Color lowHeatColour = Color.red;
        public float lowHeatAmount = 0.3f;
        public Slider warmthBar;
    }
    public Warmth warmth;

    [HideInInspector]
    private float healthSteps;
    float healthCount;
    float warmthCount;
    private float warmthSteps;

    public float currentHealth;
    public float currentWarmth;


    // Use this for initialization
    void Start () {
        currentHealth = health.startHealth;
        healthSteps = health.intervals;
        currentWarmth = warmth.startWarmth;
        warmthSteps = warmth.intervals;
        health.healthBar.maxValue = health.startHealth;
        warmth.warmthBar.maxValue = warmth.startWarmth;

    }
	
	// Update is called once per frame
	void Update () {

        UpdateHealth();
        UpdateWarmth();

        // check if player is dead
        IsDead();
    }

    //void CheckHealth()
    //{
    //    float healthCheck = currentHealth / health.startHealth;

    //    if(healthCheck >= health.midHealthAmount)
    //    {
    //        health.healthBar.color = health.goodHealthColour;
    //    }
    //    if (healthCheck < health.midHealthAmount)
    //    {
    //        health.healthBar.color = health.midHealthColour;
    //    }
    //    if (healthCheck < health.lowHealthAmount)
    //    {
    //        health.healthBar.color = health.lowHealthColour;
    //    }
    //}

    //void CheckHeat()
    //{
    //    float heatCheck = currentWarmth / heat.startHeat;

    //    if (heatCheck >= heat.midHeatAmount)
    //    {
    //        heat.warmthBar.color = heat.goodHeatColour;
    //    }
    //    if (heatCheck < heat.midHeatAmount)
    //    {
    //        heat.warmthBar.color = heat.midHeatColour;
    //    }
    //    if (heatCheck < heat.lowHeatAmount)
    //    {
    //        heat.warmthBar.color = heat.lowHeatColour;
    //    }
    //}

    public void IncreaseHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > 100)
            currentHealth = 100;

       
    }

    public void IncreaseWarmth(float amount)
    {
        currentWarmth += 100.0f;

        if (currentWarmth > warmth.startWarmth)
            currentWarmth = warmth.startWarmth;

    }

    private void IsDead()
    {
        if (currentHealth == 0 || currentWarmth == 0)
            FindObjectOfType<GameManager>().GameOver();
        
    }

    void UpdateHealth()
    {
    
        healthSteps -= Time.deltaTime;

        // decrease health over time
        if (healthSteps <= 0)
        {
            healthSteps = health.intervals;
            currentHealth -= health.reduceHealthAmount;
        }

        // clamp health to zero
        if (currentHealth <= 0)
            currentHealth = 0;

        // update health bar
        health.healthBar.value = currentHealth;
    }

    void UpdateWarmth()
    {
        warmthSteps -= Time.deltaTime;

        // decrease warmth over time
        if (warmthSteps <= 0)
        {
            warmthSteps = warmth.intervals;
            currentWarmth -= warmth.reduceWarmthAmount;
        }

        // clamp warmth to zero
        if (currentWarmth <= 0)
            currentWarmth = 0;

        // update warmth bar
        warmth.warmthBar.value = currentWarmth;
    }
}
