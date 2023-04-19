using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        healthBar = GetComponent<Slider>();
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }

    private void Update()
    {
        SetHealth(playerHealth.health);
    }

    public void initialHealth(PlayerHealth myPlayerHealth)
    {
        playerHealth = myPlayerHealth;
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;
    }
}
