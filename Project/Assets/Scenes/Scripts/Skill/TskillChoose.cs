using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TskillChoose : MonoBehaviour
{
    public int skillindex = 0;
    public int sendindex1;
    public Sprite heal;
    public Sprite speed;
    public Sprite bla;
    public Sprite magic;
    public Sprite clear;
    public Sprite Change;
    bool skill1 = false;
    public Button Q;
    public Sprite before;
    public GameObject Data;
   // public Text time;
    private Sprite[] Sprites;
    public int buttonindex = -1;
    private GameObject frame1;
    private int[] randomskills;
    // Start is called before the first frame update
    void Start()
    {
       /* Sprite[] list = { before, heal, speed, bla, magic, clear, Change };
        Sprites = list;
        randomskills = UniqRandom(5, 3);
        GameObject allskill = GameObject.Find("TSkillList");
        for (int i = 0; i < allskill.transform.childCount; i++)
        {
            allskill.transform.GetChild(i).gameObject.SetActive(false);
        }
        foreach (int i in randomskills)
        {
            allskill.transform.GetChild(i).gameObject.SetActive(true);
        }
        sendindex1 = 0;
        frame1 = Q.gameObject.transform.GetChild(0).gameObject;
        frame1.GetComponent<Image>().sprite = before;*/
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void Changeicon(int index)
    {
        buttonindex = index;
        if (index == 0)
        {
            frame1.GetComponent<Image>().sprite = Change;
            if (skillindex != 0)
            {
                sendindex1 = skillindex;
                Q.GetComponent<Image>().sprite = Sprites[sendindex1];
                skillindex = 0;
            }
        }
      
    }
    public void next()
    {
        sendindex1 = randomskills[0];
        //Data.GetComponent<TrapData>().skillindex1 = sendindex1;
       // SceneManager.LoadScene("GameScene");
    }
    public int[] IntialSkill()
    {
        Sprite[] list = { before, heal, speed, magic, clear, Change };
        Sprites = list;
        Status MyStatusScript = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>();
        int NowSkillNumber = 0;
        switch (MyStatusScript.round)
        {
            case 1:
                NowSkillNumber = 2;
                break;
            case 2:
                NowSkillNumber = 3;
                break;
            case 3:
                NowSkillNumber = 4;
                break;
            default:
                NowSkillNumber = 2;
                break;
        }
        randomskills = UniqRandom(4, NowSkillNumber);
        GameObject allskill = GameObject.Find("TSkillList");
        for (int i = 0; i < allskill.transform.childCount; i++)
        {
            allskill.transform.GetChild(i).gameObject.SetActive(false);
        }
        foreach (int i in randomskills)
        {
            allskill.transform.GetChild(i).gameObject.SetActive(true);
        }
        sendindex1 = 0;
        frame1 = Q.gameObject.transform.GetChild(0).gameObject;
        frame1.GetComponent<Image>().sprite = before;
        return randomskills;
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
