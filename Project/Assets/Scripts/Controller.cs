using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public float Preparetime = 30.0f;
    public float Gametime = 90.0f;
    public Text time;
    public Text time2;
    public int PlayerRole;
    GameObject final;
    public bool GameStart;
    //0 is adventure, 1 is troublemake

    /*
    private Controller GameController;
    private int PR;

    GameController = GameObject.Find("Controller").GetComponent<Controller>();
    PR = GameController.PlayerRole;
    */

    void Start()
    {
        GameObject Status = GameObject.FindGameObjectWithTag("Status");
        final = GameObject.FindGameObjectWithTag("Result");
       
        PlayerRole = Status.GetComponent<Status>().status;
        final.GetComponent<Result>().PR = PlayerRole;
       GameStart = false;
        if (PlayerRole == 1)
        {
            GameObject.Find("AdventureUIAndUICamera").SetActive(false);
            GameObject.Find("TroubleMakerAndUICamera").SetActive(true);
            PhotonNetwork.Instantiate("TroubleMake", new Vector3(200f, 70f, 0f), Quaternion.identity);
            GameObject[] grids = GameObject.FindGameObjectsWithTag("Grids");
            foreach (GameObject grid in grids)
            {
                grid.GetComponent<GridsController>().initialGrid();
            }
        }
        else
        {
            GameObject.Find("AdventureUIAndUICamera").SetActive(true);
            GameObject.Find("TroubleMakerAndUICamera").SetActive(false);
            PhotonNetwork.Instantiate("Player", new Vector3(12f, 7f, 0f), Quaternion.identity);
            EnemyCreation();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Preparetime > 0)
        {
            GameStart = false;
            Preparetime -= Time.deltaTime;
            //time.text = "Time Remain:" + ((int)totaltime).ToString();
            time.text = ((int)Preparetime).ToString();
            time.color = Color.yellow;
            time2.text = ((int)Preparetime).ToString();
            time2.color = Color.yellow;
        }
        else if (Gametime > 0)
        {
            if (!GameStart)
            {
                GameObject[] IBs = GameObject.FindGameObjectsWithTag("InitialBlocks");
                foreach(GameObject IB in IBs)
                {
                    IB.SetActive(false);
                }
                GameStart = true;
            }
            Gametime -= Time.deltaTime;
            //time.text = "Time Remain:" + ((int)totaltime).ToString();
            time.text = ((int)Gametime).ToString();
            time.color = Color.white;
            time2.text = ((int)Gametime).ToString();
            time2.color = Color.white;
        }
        else 
        {
            final.GetComponent<Result>().score = (int)(Gametime * 0.5 + score);
            SceneManager.LoadScene("Conclusion");
            Debug.Log("Out Of Time0");
        }

        if (final.GetComponent<Result>().death)
        {
            final.GetComponent<Result>().score = (int)(Gametime * 0.5 + score);
            SceneManager.LoadScene("Conclusion");
        }

    }

    void EnemyCreation()
    {
        for (int i = 0; i < 10; i++)
        {
            PhotonNetwork.Instantiate("Enemy", new Vector3(83f, 93f, 0f), Quaternion.identity);
        }
        for (int i = 0; i < 10; i++)
        {
            PhotonNetwork.Instantiate("Enemy", new Vector3(93f, 112f, 0f), Quaternion.identity);
        }
        for (int i = 0; i < 10; i++)
        {
            PhotonNetwork.Instantiate("Enemy", new Vector3(110f, 96f, 0f), Quaternion.identity);
        }
    }
}

