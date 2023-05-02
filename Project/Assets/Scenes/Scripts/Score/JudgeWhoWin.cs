using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JudgeWhoWin : MonoBehaviourPunCallbacks
{
    public Score yourScore;
    public Score otherScore;
    public GameObject Win;
    public GameObject Lose;

    /*
    private int yourFinalScore;
    private int otherFinalScore;
    */

    public AudioSource musicSource;

    public bool YouFinsh;
    public bool OtherFinsh;
    public float showtime;
    // Start is called before the first frame update
    void Start()
    {
        /*
        yourFinalScore = yourScore.firstScoreFinal + yourScore.secondScoreFinal + yourScore.thirdScoreFinal;
        otherFinalScore = otherScore.firstScoreFinal + otherScore.secondScoreFinal + otherScore.thirdScoreFinal;
        */
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(yourScore.finishCal);
        if (yourScore.finishCal && otherScore.finishCal)
        {
            if (yourScore.endScores > otherScore.endScores)
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
            if (showtime > 0)
            {
                showtime -= Time.deltaTime;

            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("Status"));
                PhotonNetwork.LeaveRoom();
            }
        }
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("1");
    }
}
