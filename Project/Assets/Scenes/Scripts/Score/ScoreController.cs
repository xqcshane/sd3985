using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public bool bounus;
    public int status;
    void Start()
    {
        int round = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().round;
        status= GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status;
        if (round == 1)
        {
            score = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score1;
        }
        else if (round == 2)
        {
            score = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score2;
        }
        else if (round == 3)
        {
            score = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score3;
        }
    }
    private void Update()
    {
        int round = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().round;
        
        if (status == 0)
        {
            if (round == 1)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score1 = score;
            }
            else if (round == 2)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score2 = score;
            }
            else if (round == 3)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score3 = score;
            }
        }

    }
    public void addScore(int number)
    {
        if (status == 0)
        {
            if (bounus)
            {
                score += number * 2;
            }
            else
            {
                score += number;
            }
        }
    }
    

    
   
}
