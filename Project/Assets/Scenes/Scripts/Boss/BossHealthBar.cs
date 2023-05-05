using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    //public Slider healthBar;
    public BossFollow bossHealth;
    public Image currentHealthBar;
    public float healthPoint;
    public float maxhealthPoint;
    private void Start()
    {
        //healthBar = GetComponent<Slider>();
        currentHealthBar = gameObject.transform.GetChild(3).transform.GetChild(0).GetComponent<Image>();
    }

    public void BossSetHealth(float hp)
    {
        //healthBar.value = hp;
        healthPoint = hp;
        UpdatehealthBar();

    }

    private void Update()
    {
        if (bossHealth != null)
        {
            BossSetHealth(bossHealth.health);
        }
    }
    public void initialHealth(BossFollow myBossHealth)
    {
        bossHealth = myBossHealth;
        //healthBar.maxValue = playerHealth.maxHealth;
        //healthBar.value = playerHealth.maxHealth;
        healthPoint = bossHealth.health;
        maxhealthPoint = bossHealth.health;
    }
    private void UpdatehealthBar()
    {
        float ratio = healthPoint / maxhealthPoint;
        currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * ratio - currentHealthBar.rectTransform.rect.width, 0, 0);
    }
}

