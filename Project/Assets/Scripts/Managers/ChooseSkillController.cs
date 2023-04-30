using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChooseSkillController : MonoBehaviour
{
    private int status;
    // Start is called before the first frame update
    void Start()
    {
        int status = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status;
        if (status==0)
        {
            //status = 0;
            GameObject.Find("Adventure").SetActive(true);         
            GameObject.Find("Troublemaker").SetActive(false);
            GameObject.Find("TrapManager").SetActive(false) ;
            GameObject.Find("TrapManager2").SetActive(false);
            GameObject.Find("Troublemakerskill").SetActive(false);
            GameObject.Find("TSkillManager2").SetActive(false);
            GameObject.Find("TSkillManager").SetActive(false);
        }
        else
        {
            //status = 1;
            GameObject.Find("Adventure").SetActive(false);
            GameObject.Find("Troublemaker").SetActive(true);
            GameObject.Find("SkillManager").SetActive(false);
            GameObject.Find("SkillManager2").SetActive(false);
            GameObject.Find("TSkillManager").GetComponent<TskillChoose>().IntialSkill();
            GameObject.Find("Troublemakerskill").SetActive(false);
        }

       // GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status = status;
    }
    

}
