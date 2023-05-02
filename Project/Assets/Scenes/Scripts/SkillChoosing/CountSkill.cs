using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountSkill : MonoBehaviour
{
    public static int[] skills = new int[5];
    public static int index = 0;

    public void AddSkill(int skillIndex)
    {
        bool flag = false;
        for (int i = 0; i< 5; i++)
        {
            if (skills[i] == skillIndex)
            {
                flag = true;
            }
        }
        if (!flag)
        {
            skills[index] = skillIndex;
            index++;
        }
    }

    public void ShowAllSkill()
    {
        for (int j = 0; j < 5; j++)
        {
            if (skills[j] != 0)
            {
                Debug.Log(skills[j]);
            }
        }
    }
}
