using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //public Slider healthBar;
    public PlayerHealth playerHealth;
    public Image currentManaBar;
    public int manaPoint;
    public int maxManaPoint; 
    private void Start()
    { 
        //healthBar = GetComponent<Slider>();
        currentManaBar=gameObject.transform.GetChild(3).transform.GetChild(0).GetComponent<Image>();
    }

    public void SetHealth(int hp)
    {
        //healthBar.value = hp;
        if (hp < maxManaPoint)
        {
            manaPoint = hp;
            UpdateManaBar();
        }
        
    }

    private void Update()
    {
        if (playerHealth != null)
        {
            SetHealth(playerHealth.health);
        }
    }
    public void initialHealth(PlayerHealth myPlayerHealth)
    {
        playerHealth = myPlayerHealth;
        //healthBar.maxValue = playerHealth.maxHealth;
        //healthBar.value = playerHealth.maxHealth;
        manaPoint = playerHealth.maxHealth;
        maxManaPoint = playerHealth.maxHealth;
    }
    private void UpdateManaBar()
    {
        float ratio = (float)manaPoint / (float)maxManaPoint;
        currentManaBar.rectTransform.localPosition = new Vector3(currentManaBar.rectTransform.rect.width * ratio - currentManaBar.rectTransform.rect.width, 0, 0);
    }
}
