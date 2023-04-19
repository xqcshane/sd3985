using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowResult : MonoBehaviour
{
    GameObject final;
    public Text result;
    public Text score;
    void Start()
    {
        final = GameObject.FindGameObjectWithTag("Result");
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

  
}
