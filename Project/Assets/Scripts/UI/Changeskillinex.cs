using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Changeskillinex : MonoBehaviour
{
    // Start is called before the first frame update
    public Button Q;
    public Button E;
public void skill(int index)
    {

        GameObject skill = GameObject.FindWithTag("Skill");
        skill.GetComponent<Skillchoose>().skillindex = index;      
    }

}
