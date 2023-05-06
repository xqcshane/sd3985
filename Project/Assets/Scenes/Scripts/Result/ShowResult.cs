using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.AssetImporters;
using TMPro;

public class ShowResult : MonoBehaviour
{
    GameObject final;
    public Text result;
    public Text score;

    //public Text result2;
    public Text score2;
    public Text score3;
    public float showtime = 10.0f;
    public TextMeshProUGUI MyRat;
    void Start()
    {
        final = GameObject.FindGameObjectWithTag("Status");
        int myrole = final.GetComponent<Status>().status;
        MyRat.text = "Round: " + GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().round.ToString() + "\nTurn: " + GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().turn.ToString();
        int MyRound = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().round;
        int MyTurn = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().turn;
        if (myrole == 0)
        {
            GameObject.Find("Adventure").SetActive(true);
            GameObject.Find("Troublemaker").SetActive(false);

            if (!final.GetComponent<Status>().death)
            {
                result.text = "Time Out";
                //score.text = "Your total score is :" + (final.GetComponent<Result>().score).ToString();
                if (MyRound == 3 && MyTurn == 2)
                {
                    score.text = "Game Over";
                }
                else
                {
                    score.text = "You will be the Reverager";
                }
            }
            else
            {
                result.text = "You Dead";
                if (MyRound == 3 && MyTurn == 2)
                {
                    score.text = "Game Over";
                }
                else
                {
                    score.text = "Reverage Next turn";
                }
                final.GetComponent<Status>().death = false;
            }
        }
        else
        {
            GameObject.Find("Adventure").SetActive(false);
            GameObject.Find("Troublemaker").SetActive(true);
            if (MyRound == 3 && MyTurn == 2)
            {
                score3.text = "See the Result";
            }
            else
            {
                score3.text = "You will be the adventurer next turn";
            }
            if (!final.GetComponent<Status>().death)
            {
                
                if (MyRound == 3 && MyTurn == 2)
                {
                    score2.text = "Game Over";
                }
                else
                {
                    score2.text = "You Block the Conqueror";
                }

            }
            else
            {
                if (MyRound == 3 && MyTurn == 2)
                {
                    score2.text = "Game Over";
                }
                else
                {
                    score2.text = "You Kill the Conqueror";
                }
                final.GetComponent<Status>().death = false;
            }
        }
        Destroy(GameObject.FindGameObjectWithTag("SkillData"));
        Destroy(GameObject.FindGameObjectWithTag("TrapData"));
        //Destroy(GameObject.Find("result"));
        // Destroy(GameObject.)

    }

    private void Update()
    {
        if (showtime > 0)
        {
            showtime -= Time.deltaTime;
        }
        else
        {
            CheckAndChangeScene();
        }
    }


    public void CheckAndChangeScene()
    {
        int MyRound = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().round;
        int MyTurn = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().turn;
        if (MyRound == 3 && MyTurn == 2)
        {
            SceneManager.LoadScene("Score");
        }
        else if (MyTurn == 1)
        {
            GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().turn = 2;
            SceneManager.LoadScene("Roles");
        }
        else if (MyTurn == 2)
        {
            GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().round++;
            GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().turn = 1;
            SceneManager.LoadScene("Roles");
        }
    }


}