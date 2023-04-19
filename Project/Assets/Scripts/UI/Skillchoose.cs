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
    void Start()
    {
        before = Q.GetComponent<Image>().sprite;
        
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
        Changeicon();
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
    private void Changeicon()
    {
        if (skillindex == 1 )
        {
            if (skill1)
            {
                Q.GetComponent<Image>().sprite = heal;
                sendindex1 = 1;
            }
            else
            {
                E.GetComponent<Image>().sprite = heal;
                sendindex2 = 1;

            }
        }
        else if (skillindex == 2)
        {
            if (skill1)
            {
                Q.GetComponent<Image>().sprite = speed;
                sendindex1 = 2;

            }
            else
            {
                E.GetComponent<Image>().sprite = speed;
                sendindex2 = 2;

            }
        }
        else if (skillindex == 3)
        {
            if (skill1)
            {
                Q.GetComponent<Image>().sprite = bla;
                sendindex1 = 3;

            }
            else
            {
                E.GetComponent<Image>().sprite = bla;
                sendindex2 = 3;
            }
        }
        else if (skillindex == 4)
        {
            if (skill1)
            {
                Q.GetComponent<Image>().sprite = magic;
                sendindex1 = 4;
            }
            else
            {
                E.GetComponent<Image>().sprite = magic;
                sendindex2 = 4;
            }
        }
        else if (skillindex == 5)
        {
            if (skill1)
            {
                Q.GetComponent<Image>().sprite = clear;
                sendindex1 = 5;
            }
            else
            {
                E.GetComponent<Image>().sprite = clear;
                sendindex2 = 5;
            }
        }
    }
    public void next()
    {
        Data.GetComponent<SkillData>().skillindex1 = sendindex1;
        Data.GetComponent<SkillData>().skillindex2 = sendindex2;
        SceneManager.LoadScene("GameScene");
    }
}
