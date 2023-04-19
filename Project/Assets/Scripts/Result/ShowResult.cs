using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowResult : MonoBehaviour
{
    GameObject final;
    public Text result;
    public Text score;

    //public Text result2;
    public Text score2;
    void Start()
    {   
        final = GameObject.FindGameObjectWithTag("Result");
        int myrole = final.GetComponent<Result>().PR;
        if (myrole == 0)
        {
            GameObject.Find("Adventure").SetActive(true);
            GameObject.Find("Troublemaker").SetActive(false);
            
            if (!final.GetComponent<Result>().death)
            {
                result.text = "Time Out";
                score.text = "Your total score is :" + (final.GetComponent<Result>().score).ToString();
            }
            else
            {
                result.text = "You Dead";
                score.text = "GameOver";
            }
        }
        else
        {
            GameObject.Find("Adventure").SetActive(false);
            GameObject.Find("Troublemaker").SetActive(true);
            if (!final.GetComponent<Result>().death)
            {
                score2.text = "You Block the Adventure";
            }
            else
            {
                score2.text = "You Kill the Adventure";
            }
        }

    }

  
}
