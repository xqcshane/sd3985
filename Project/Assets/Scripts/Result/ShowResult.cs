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
    public float showtime = 10.0f;
    public TextMeshProUGUI MyRat;
    void Start()
    {   
        final = GameObject.FindGameObjectWithTag("Result");
        int myrole = final.GetComponent<Result>().PR;
        MyRat.text = "Round: " + GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().round.ToString() + "\nTurn: " + GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().turn.ToString();

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
        Destroy(GameObject.Find("Data1"));
        Destroy(GameObject.Find("Data2"));
        Destroy(GameObject.Find("result"));
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
        if(MyRound == 3 && MyTurn == 2)
        {
            SceneManager.LoadScene("Score");
        }else if (MyTurn == 1)
        {
            GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().turn = 2;
            SceneManager.LoadScene("Roles");
        }
        else if(MyTurn == 2)
        {
            GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().round ++;
            GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().turn = 1;
            SceneManager.LoadScene("Roles");
        }
}


}
