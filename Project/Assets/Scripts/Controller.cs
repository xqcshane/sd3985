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
    public bool endGame=false;
    public Vector3[] StartPoint;
    public GameObject Status;
    public GameObject score2;
    //0 is adventure, 1 is troublemake

    /*
    private Controller GameController;
    private int PR;

    GameController = GameObject.Find("Controller").GetComponent<Controller>();
    PR = GameController.PlayerRole;
    */

    void Start()
    {        
        Status = GameObject.FindGameObjectWithTag("Status");
        final = GameObject.FindGameObjectWithTag("Status");
       
        PlayerRole = Status.GetComponent<Status>().status;
        //final.GetComponent<Result>().PR = PlayerRole;
        GameStart = false;

        if (PlayerRole == 1)
        {
            GameObject.Find("AdventureUIAndUICamera").SetActive(false);
            GameObject.Find("TroubleMakerAndUICamera").SetActive(true);
            PhotonNetwork.Instantiate("TroubleMake", new Vector3(200f, 70f, 0f), Quaternion.identity);
            /*
            GameObject[] grids = GameObject.FindGameObjectsWithTag("Grids");
            foreach (GameObject grid in grids)
            {
                grid.GetComponent<GridsController>().initialGrid();
            }
            */
        }
        else
        {
            GameObject.Find("AdventureUIAndUICamera").SetActive(true);
            GameObject.Find("TroubleMakerAndUICamera").SetActive(false);
            int[] myrandom = UniqueRandom(4, 4);
            PhotonNetwork.Instantiate("Player", StartPoint[myrandom[0]], Quaternion.identity);
            PhotonNetwork.Instantiate("bomb", StartPoint[myrandom[1]], Quaternion.identity);
            PhotonNetwork.Instantiate("fast", StartPoint[myrandom[2]], Quaternion.identity);
            PhotonNetwork.Instantiate("shotgun", StartPoint[myrandom[3]], Quaternion.identity);
            if (Status.GetComponent<Status>().turn == 1)
            {
                GameObject.Find("BasicRoom").GetComponent<RoomRandomController>().StartRandomRooms();
            }
            else
            {
                GameObject.Find("BasicRoom").GetComponent<RoomRandomController>().StartFixedRooms(Status.GetComponent<Status>().roominfo);
            }
            //nemyCreation();
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
                if (PlayerRole == 0) {
                    GameObject.Find("AdventureCanvas").GetComponent<PointerCreater>().StartInitialPointer();
                }
                if (PlayerRole == 1)
                {
                    
                    GameObject.Find("ImageEmoji").GetComponent<EmojiController>().CanUseEmoji = true;
                    GameObject.FindGameObjectWithTag("TroubleMaker").GetComponent<TMSetTrapViewController>().CanChangeView = false;
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
            if (Status.GetComponent<Status>().round == 1)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score1 = score2.GetComponent<ScoreController>().score + 10 * ((int)Gametime % 10);
            }
            else if (Status.GetComponent<Status>().round == 2)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score2 = score2.GetComponent<ScoreController>().score + 10 * ((int)Gametime % 10);
            }
            else if (Status.GetComponent<Status>().round == 3)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score3 = score2.GetComponent<ScoreController>().score + 10 * ((int)Gametime % 10);
            }
            SceneManager.LoadScene("Conclusion");
            Debug.Log("Out Of Time0");
        }
        if (endGame)
        {
            if (Status.GetComponent<Status>().round == 1)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score1= score2.GetComponent<ScoreController>().score+10*((int)Gametime%10);
            }
            else if (Status.GetComponent<Status>().round == 2)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score2= score2.GetComponent<ScoreController>().score+ 10 * ((int)Gametime % 10);
            }
            else if (Status.GetComponent<Status>().round == 3)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score3= score2.GetComponent<ScoreController>().score+ 10 * ((int)Gametime % 10);
            }
            SceneManager.LoadScene("Conclusion");
        }
        if (final.GetComponent<Status>().death)
        {
            if (Status.GetComponent<Status>().round == 1)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score1 = score2.GetComponent<ScoreController>().score + 10 * ((int)Gametime % 10);
            }
            else if (Status.GetComponent<Status>().round == 2)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score2 = score2.GetComponent<ScoreController>().score + 10 * ((int)Gametime % 10);
            }
            else if (Status.GetComponent<Status>().round == 3)
            {
                GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().score3 = score2.GetComponent<ScoreController>().score + 10 * ((int)Gametime % 10);
            }
            SceneManager.LoadScene("Conclusion");
        }

    }

   

    public int[] UniqueRandom(int RandomNumber, int NeedNumber)
    {
        int[] randomskills = new int[NeedNumber];
        int maxnumber = 0;
        while (maxnumber < NeedNumber)
        {
            int num = Random.Range(1, RandomNumber + 1);
            bool isOnList = false;
            foreach (int i in randomskills)
            {
                if (i == num)
                {
                    isOnList = true;
                }
            }
            if (!isOnList)
            {
                randomskills[maxnumber] = num;
                maxnumber++;
            }
        }
        for (int i = 0; i < randomskills.Length; i++)
        {
            randomskills[i] = randomskills[i] - 1;
        }
        return randomskills;
    }
}

