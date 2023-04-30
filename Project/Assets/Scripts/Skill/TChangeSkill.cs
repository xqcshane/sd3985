using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TChangeSkill : MonoBehaviour
{
    public void skill(int index)
    {

        GameObject skill = GameObject.FindWithTag("TSkill");
        //skill.GetComponent<TrapChoosing>().skillindex = index;
        int button = skill.GetComponent<TrapChoosing>().buttonindex;
        if (button != -1)
        {
            skill.GetComponent<TrapChoosing>().skillindex = index;

            skill.GetComponent<TrapChoosing>().Changeicon(button);
        }
    }
}
