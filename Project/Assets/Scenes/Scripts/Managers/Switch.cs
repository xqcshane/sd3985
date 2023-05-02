using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public  void GoSkill()
    {
        GameObject.Find("Trap").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Skill").transform.GetChild(0).gameObject.SetActive(true);
    }
    public void GoTrap()
    {
        GameObject.Find("Trap").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("Skill").transform.GetChild(0).gameObject.SetActive(false);
    }
}
