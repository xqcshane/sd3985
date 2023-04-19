using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeTrapIndex : MonoBehaviour
{
    // Start is called before the first frame update
 
    public void skill(int index)
    {

        GameObject skill = GameObject.FindWithTag("Traps");
        skill.GetComponent<TrapChoosing>().skillindex = index;
    }
}
