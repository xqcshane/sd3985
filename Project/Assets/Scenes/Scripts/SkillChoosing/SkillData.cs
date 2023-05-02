using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData : MonoBehaviour
{
    public int skillindex1;
    public int skillindex2;
    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
   
}
