using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TrapChoosing : MonoBehaviour
{
    // same logic as the skillchoosing but three button
    public int skillindex = 0;
    public int sendindex1;
    public int sendindex2;
    public int sendindex3;
    public Sprite heal;
    public Sprite speed;
    public Sprite bla;
    public Sprite magic;
    public Sprite clear;
    public Sprite Change;
    bool skill1 = false;
    bool skill2 = false;
    bool skill3=false;
    bool skilllock = false;
    public Button Q;
    public Button E;
    public Button trap3;
    public Sprite before;
    public GameObject Data;
    public float totaltime = 10.0f;
    public Text time;
    private Sprite[] Sprites;
    public int buttonindex = -1;
    private GameObject frame1;
    private GameObject frame2;
    private GameObject frame3;
    void Start()
    {
        before = Q.GetComponent<Image>().sprite;
        Sprite[] list = { before, heal, speed, bla, magic, clear, Change };
        Sprites = list;
        int[] randomskills = UniqRandom(7, 5);
        GameObject allskill = GameObject.Find("TTrapList");
        for (int i = 0; i < allskill.transform.childCount; i++)
        {
            allskill.transform.GetChild(i).gameObject.SetActive(false);
        }
        foreach (int i in randomskills)
        {
            allskill.transform.GetChild(i).gameObject.SetActive(true);
        }
        sendindex1 = 0;
        sendindex2 = 0;
        sendindex3 = 0;
        frame1 = Q.gameObject.transform.GetChild(0).gameObject;
        frame2 = E.gameObject.transform.GetChild(0).gameObject;
        frame3= trap3.gameObject.transform.GetChild(0).gameObject;
        frame1.GetComponent<Image>().sprite = before;
        frame2.GetComponent<Image>().sprite = before;
        frame3.GetComponent<Image>().sprite = before;

    }
    public void chooseskill(int index)
    {
        // find the skill
        if (index == 0)
        {

            Q.GetComponent<Image>().sprite = Change;
            skill1 = true;
            skill2 = false;
            skill3 = false;
            if (E.GetComponent<Image>().sprite == Change)
            {
                E.GetComponent<Image>().sprite = before;
            }
            if (trap3.GetComponent<Image>().sprite == Change)
            {
                trap3.GetComponent<Image>().sprite = before;
            }
            sendindex1 = 1;
        }
        else if (index == 1)
        {
            E.GetComponent<Image>().sprite = Change;
            skill2 = true;
            skill1 = false;
            skill3 = false;
            if (Q.GetComponent<Image>().sprite == Change)
            {
                Q.GetComponent<Image>().sprite = before;
            }
            if (trap3.GetComponent<Image>().sprite = Change)
            {
                trap3.GetComponent<Image>().sprite = before;
            }
            sendindex2 = 2;
        }
        else if (index == 2)
        {
            trap3.GetComponent<Image>().sprite = Change;
            skill3 = true;
            skill1 = false;
            skill2 = false;
            if (Q.GetComponent<Image>().sprite == Change)
            {
                Q.GetComponent<Image>().sprite = before;
            }
            if (E.GetComponent<Image>().sprite == Change)
            {
                E.GetComponent<Image>().sprite = before;
            }

            sendindex3 = 3;
        }

    }
    private void Update()
    {
        Changeicon();
        if (totaltime > 0)
        {
            time.text = "Time Remain:" + ((int)totaltime).ToString();
            totaltime -= Time.deltaTime;
        }
        else
        {
            next();
        }
    }
    private void Changeicon()
    {
        if (skillindex == 1)
        {
            if (skill1)
            {
                Q.GetComponent<Image>().sprite = heal;
                sendindex1 = 1;
            }
            else if(skill2) 
            {
                E.GetComponent<Image>().sprite = heal;
                sendindex2 = 1;

            }
            else
            {
                trap3.GetComponent<Image>().sprite = heal;
                sendindex3 = 1;
            }
        }
        else if (skillindex == 2)
        {
            if (skill1)
            {
                Q.GetComponent<Image>().sprite = speed;
                sendindex1 = 2;

            }
            else if(skill2)
            {
                E.GetComponent<Image>().sprite = speed;
                sendindex2 = 2;

            }
            else
            {
                trap3.GetComponent<Image>().sprite = speed;
                sendindex3 = 2;
            }
        }
        else if (skillindex == 3)
        {
            if (skill1)
            {
                Q.GetComponent<Image>().sprite = bla;
                sendindex1 = 3;

            }
            else if(skill2)
            {
                E.GetComponent<Image>().sprite = bla;
                sendindex2 = 3;
            }
            else
            {
                trap3.GetComponent<Image>().sprite = bla;
                sendindex3 = 3;
            }
        }
        else if (skillindex == 4)
        {
            if (skill1)
            {
                Q.GetComponent<Image>().sprite = magic;
                sendindex1 = 4;
            }
            else if(skill2)
            {
                E.GetComponent<Image>().sprite = magic;
                sendindex2 = 4;
            }
            else
            {
                trap3.GetComponent<Image>().sprite = magic;
                sendindex3 = 4;
            }
        }
        else if (skillindex == 5)
        {
            if (skill1)
            {
                Q.GetComponent<Image>().sprite = clear;
                sendindex1 = 5;
            }
            else if(skill2)
            {
                E.GetComponent<Image>().sprite = clear;
                sendindex2 = 5;
            }
            else
            {
                trap3.GetComponent<Image>().sprite = clear;
                sendindex3 = 5;
            }
        }
    }
    public void next()
    {
        Data.GetComponent<TrapData>().skillindex1 = sendindex1;
        Data.GetComponent<TrapData>().skillindex2 = sendindex2;
        Data.GetComponent<TrapData>().skillindex3= sendindex3;
        SceneManager.LoadScene("GameScene");
    }
    public int[] UniqRandom(int RandomNumber, int NeedNumber)
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
