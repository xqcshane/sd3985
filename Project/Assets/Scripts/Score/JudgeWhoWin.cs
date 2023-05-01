using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeWhoWin : MonoBehaviour
{
    public Score yourScore;
    public Score otherScore;
    public GameObject Win;
    public GameObject Lose;

    private int yourFinalScore;
    private int otherFinalScore;

    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        yourFinalScore = yourScore.firstScoreFinal + yourScore.secondScoreFinal + yourScore.thirdScoreFinal;
        otherFinalScore = otherScore.firstScoreFinal + otherScore.secondScoreFinal + otherScore.thirdScoreFinal;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(yourScore.finishCal);
        if (yourScore.finishCal && otherScore.finishCal)
        {
            if (yourFinalScore > otherFinalScore)
            {
                Win.SetActive(true);
                Win.GetComponent<Animator>().Play("Win");
                musicSource.Stop();
            }
            else
            {
                Lose.SetActive(true);
                Lose.GetComponent<Animator>().Play("Lose");
                musicSource.Stop();
            }
        }
    }
}
