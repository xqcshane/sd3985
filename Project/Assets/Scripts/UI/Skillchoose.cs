using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class Skillchoose : MonoBehaviour
{
  
    public int skillindex=0;
    public int sendindex1;
    public int sendindex2;
    public Sprite heal;
    public Sprite speed;
    public Sprite bla;
    public Sprite magic;
    public Sprite clear;
    public Sprite Change;
    bool skill1=false;
    bool skill2=false;
    bool skilllock=false;
    public Button Q;
    public Button E;
    public Sprite before;
    public GameObject Data;
    public float totaltime = 10.0f;
    public Text time;
    private Sprite[] Sprites;
    public int buttonindex=-1;
    private GameObject frame1;
    private GameObject frame2;
    void Start()
    {
        Sprite[] list = {before, heal, speed, bla, magic, clear, Change};
        Sprites = list;
        int[] randomskills = UniqRandom(7,5);
        GameObject allskill = GameObject.Find("ASkillList");
        for(int i=0; i < allskill.transform.childCount; i++)
        {
            allskill.transform.GetChild(i).gameObject.SetActive(false);
        }
        foreach (int i in randomskills)
        {
            allskill.transform.GetChild(i).gameObject.SetActive(true);
        }
        sendindex1 = 0;
        sendindex2 = 0;
        frame1 = Q.gameObject.transform.GetChild(0).gameObject;
        frame2=E.gameObject.transform.GetChild(0).gameObject;
        frame1.GetComponent<Image>().sprite = before;
        frame2.GetComponent<Image>().sprite = before;
    }
   
        public void chooseskill(int index)
    {
        // find the skill
        if (index == 0)
        {
           
            Q.GetComponent<Image>().sprite = Change;
            skill1 = true;
            skilllock = !skilllock;
            skill2 = false;
            if (E.GetComponent<Image>().sprite == Change)
            {
                E.GetComponent<Image>().sprite = before;
            }
            sendindex1 = 0;
        }
        else if (index == 1)
        {
            E.GetComponent<Image>().sprite = Change;
            skill2 = true;
            skill1 = false;
            if (Q.GetComponent<Image>().sprite == Change)
            {
                Q.GetComponent<Image>().sprite = before;
            }
            sendindex2 = 0;
        }
       
    }
    private void Update()
    {
        //Changeicon();
        if (totaltime > 0)
        {
            time.text = "Time Remain:"+((int)totaltime).ToString();
            totaltime -= Time.deltaTime;
        }
        else
        {
            next();
        }
    }
    public void Changeicon(int index)
    {
        buttonindex = index;
        if (index == 0)
        {
                frame1.GetComponent<Image>().sprite = Change;
                frame2.GetComponent<Image>().sprite = before;
            if (skillindex != 0)
            {
                if (skillindex == sendindex2) {
                    E.GetComponent<Image>().sprite = Sprites[sendindex1];
                    sendindex2 = sendindex1;
                }
                sendindex1 = skillindex;
                Q.GetComponent<Image>().sprite = Sprites[sendindex1];
                skillindex = 0;
            }
        }
        else if (index == 1)
        {
                frame2.GetComponent<Image>().sprite = Change;
                frame1.GetComponent<Image>().sprite = before;
            if (skillindex != 0)
            {
                if (sendindex1 == skillindex)
                {
                    Q.GetComponent<Image>().sprite = Sprites[sendindex2];
                    sendindex1 = sendindex2;
                }
                sendindex2 = skillindex;
                E.GetComponent<Image>().sprite = Sprites[sendindex2];
                skillindex = 0;
            }
        }
        

       
    }
    public void next()
    {
        Data.GetComponent<SkillData>().skillindex1 = sendindex1;
        Data.GetComponent<SkillData>().skillindex2 = sendindex2;
        SceneManager.LoadScene("GameScene");
    }

    /*Changeskillinexicon(int curerentint)
    {
        E.GetComponent<Image>().sprite = Sprites[sendindex2];
        Q.GetComponent<Image>().sprite = Sprites[sendindex1];
        
    }*/
    public int[] UniqRandom(int RandomNumber, int NeedNumber)
    {
        int[] randomskills = new int[NeedNumber];
        int maxnumber = 0;
        while (maxnumber < NeedNumber)
        {
            int num = Random.Range(1, RandomNumber+ 1);
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
