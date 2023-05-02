using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int firstScoreFinal;
    public int secondScoreFinal;
    public int thirdScoreFinal;

    public Text score1;
    public Text score2;
    public Text score3;
    public Text endScore;

    private int growthScores1 = 0;
    private int growthScores2 = 0;
    private int growthScores3 = 0;
    public int endScores;

    public int growthRate = 10;
    private bool countOver = false;
    public float showtime = 20.0f;

    public bool finishCal = false;

    public bool isStart;

    // Update is called once per frame
    void Start()
    {
        isStart = false;
    }
    void Update()
    {
        if (isStart)
        {
            score1.text = growthScores1.ToString("0");
            score2.text = growthScores2.ToString("0");
            score3.text = growthScores3.ToString("0");
            endScore.text = endScores.ToString("0");


            if (growthScores1 < firstScoreFinal)
            {
                growthScores1 += growthRate;
            }

            if (growthScores2 < secondScoreFinal)
            {
                growthScores2 += growthRate;
            }

            if (growthScores3 < thirdScoreFinal)
            {
                growthScores3 += growthRate;
            }

            /*
            if (Input.GetKeyDown("space"))
            {
                scores1 += scoreValue;
            }


            if (Input.GetKeyDown("escape"))
            {
                gameOver = true;
            }
            */

            if (growthScores1 == firstScoreFinal && growthScores2 == secondScoreFinal && growthScores3 == thirdScoreFinal)
            {
                countOver = true;
            }

            if (countOver)
            {
                CountOver();
            }
            if (showtime > 0)
            {

                showtime -= Time.deltaTime;
            }
            else
            {
                //SceneManager.LoadScene("")
            }
        }

    }

    public void CountOver()
    {
        if (endScores != firstScoreFinal+ secondScoreFinal+ thirdScoreFinal)
        {
            endScores += growthRate;
        }
        else
        {
            finishCal = true;
        }
        
    }

    public void SetInitial(int s1, int s2, int s3)
    {
        firstScoreFinal = s1;
        secondScoreFinal = s2;
        thirdScoreFinal = s3;
        isStart = true;
    }
}
