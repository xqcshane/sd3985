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
    public Sprite fake;
    public Sprite monster;
    public Sprite boss;
    public Sprite Change;
    bool skill1 = false;
    bool skill2 = false;
    bool skill3=false;
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
    private int[] randomskills;
    void Start()
    {
        before = Q.GetComponent<Image>().sprite;
        Sprite[] list = { before, heal, speed, bla, magic, clear, fake,monster, boss,Change };
        Sprites = list;
        Status MyStatusScript = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>();
        int NowSkillNumber = 0;
        switch (MyStatusScript.round)
        {
            case 1:
                NowSkillNumber = 4;
                break;
            case 2:
                NowSkillNumber = 6;
                break;
            case 3:
                NowSkillNumber = 8;
                break;
            default:
                NowSkillNumber = 4;
                break;
        }
        randomskills = UniqRandom(8, NowSkillNumber);
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
   /* public void chooseskill(int index)
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

    }*/
    private void Update()
    {
        //Changeicon();
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
    public void Changeicon(int index)
    {
        buttonindex = index;
        if (index == 0)
        {
            frame1.GetComponent<Image>().sprite = Change;
            frame2.GetComponent<Image>().sprite = before;
            frame3.GetComponent<Image>().sprite = before;
            if (skillindex != 0)
            {
                if (skillindex == sendindex2)
                {
                    E.GetComponent<Image>().sprite = Sprites[sendindex1];
                    sendindex2 = sendindex1;
                }
                if (skillindex == sendindex3)
                {
                    trap3.GetComponent<Image>().sprite = Sprites[sendindex1];
                    sendindex3 = sendindex1;
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
            frame3.GetComponent<Image>().sprite = before;
            if (skillindex != 0)
            {
                if (skillindex == sendindex1)
                {
                    Q.GetComponent<Image>().sprite = Sprites[sendindex2];
                    sendindex1 = sendindex2;
                }
                if (skillindex == sendindex3)
                {
                    trap3.GetComponent<Image>().sprite = Sprites[sendindex2];
                    sendindex3 = sendindex2;
                }
                sendindex2 = skillindex;
                E.GetComponent<Image>().sprite = Sprites[sendindex2];
                skillindex = 0;
            }
        }
        else if(index == 2)
        {
            frame3.GetComponent<Image>().sprite = Change;
            frame1.GetComponent<Image>().sprite = before;
            frame2.GetComponent<Image>().sprite = before;
            if (skillindex != 0)
            {
                if (skillindex == sendindex1)
                {
                    Q.GetComponent<Image>().sprite = Sprites[sendindex3];
                    sendindex1 = sendindex3;
                }
                if (skillindex == sendindex2)
                {
                    E.GetComponent<Image>().sprite = Sprites[sendindex3];
                    sendindex2 = sendindex3;
                }
                sendindex3 = skillindex;
                trap3.GetComponent<Image>().sprite = Sprites[sendindex3];
                skillindex = 0;
            }
        }
    }
    public void next()
    {
        if (sendindex1 == 0 || sendindex2 == 0 || sendindex3 == 0)
        {
            if (sendindex1 == 0) {
                for (int i = 0; i < randomskills.Length; i++)
                {
                    if (randomskills[i] != sendindex1 && randomskills[i] != sendindex2 && randomskills[i] != sendindex3)
                    {
                        sendindex1 = randomskills[i];
                        break;
                    }
                }
            }
            if(sendindex2 == 0)
            {
                for (int i = 0; i < randomskills.Length; i++)
                {
                    if (randomskills[i] != sendindex1 && randomskills[i] != sendindex2 && randomskills[i] != sendindex3)
                    {
                        sendindex2 = randomskills[i];
                        break;
                    }
                }
            }
            if (sendindex3 == 0)
            {
                for (int i = 0; i < randomskills.Length; i++)
                {
                    if (randomskills[i] != sendindex1 && randomskills[i] != sendindex2 && randomskills[i] != sendindex3)
                    {
                        sendindex3 = randomskills[i];
                        break;
                    }
                }
            }
        }
        Data.GetComponent<TrapData>().skillindex1 = sendindex1;
        Data.GetComponent<TrapData>().skillindex2 = sendindex2;
        Data.GetComponent<TrapData>().skillindex3= sendindex3;
        Data.GetComponent<TrapData>().skill = GameObject.Find("TSkillManager").GetComponent<TskillChoose>().sendindex1;
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
