using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 0.2f;
    public int maxHealth = 100;
    public int health { get { return currentHealth; } set { currentHealth = value; } }
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if (currentHealth<=0)
        {
            GameObject final = GameObject.FindGameObjectWithTag("Result");
            final.GetComponent<Result>().death = true;
            Destroy(gameObject);

        }
    }
    public void ChangeHealth(int amount)
    {
     
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //Debug.Log(currentHealth + "/" + maxHealth);
    }
}
