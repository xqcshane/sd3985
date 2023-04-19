using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public Sprite fireicon;
    public Sprite arrowicon;
    public Sprite thronesicon;
    public Sprite slowicon;
    public Sprite moveicon;
    public int index1;
    public int index2;
    public int index3;
    public GameObject TrapUI1;
    public GameObject TrapUI2;
    public GameObject TrapUI3;
    int amount1;
    int amount2;
    int amount3;
    bool trap1;
    bool trap2;
    bool trap3;
    [Header("Traps")]
    public GameObject FireTower;
    public GameObject Arrow;
    public GameObject Thrones;
    public GameObject slow;
    public GameObject move;
    public GameObject nowtrap;
    GameObject[] traps;
    void Start()
    {
        GameObject data = GameObject.FindWithTag("TrapData");
        index1 = data.GetComponent<TrapData>().skillindex1;
        index2 = data.GetComponent<TrapData>().skillindex2;
        index3 = data.GetComponent<TrapData>().skillindex3;
        Sprite[] sprites = { fireicon, arrowicon, thronesicon, slowicon, moveicon };
        traps = new GameObject[5];
        traps[0] = FireTower;
        traps[1]=Arrow;
        traps[2]=Thrones;
        traps[3]=slow;
        traps[4] = move;
        if (index1 == 1)
        {
            amount1 = 2;
        }
        else if (index1 == 2|| index1==4||index1==5)
        {
            amount1 = 1;
        }
        else if (index1 == 3)
        {
            amount1 = 3;
        }
        TrapUI1.GetComponent<TrapUI>().ChangeTrapImage(sprites[index1-1]);
        TrapUI1.GetComponent<TrapUI>().ChangeTrapNumber(amount1.ToString());
        if (index2 == 1)
        {
            amount2 = 2;
        }
        else if(index2 == 2 || index2 == 4 || index2 == 5)
        {
            amount2 = 1;
        }
        else if (index2 == 3) {
            amount2 = 3;
        }
        TrapUI2.GetComponent<TrapUI>().ChangeTrapImage(sprites[index2 - 1]);
        TrapUI2.GetComponent<TrapUI>().ChangeTrapNumber(amount2.ToString());
        if (index3 == 1)
        {
            amount3 = 2;
        }
        else if (index3 == 2 || index3 == 4 || index3 == 5)
        {
            amount3 = 1;
        }
        else if (index3 == 3)
        {
            amount3 = 3;
        }
        TrapUI3.GetComponent<TrapUI>().ChangeTrapImage(sprites[index3 - 1]);
        TrapUI3.GetComponent<TrapUI>().ChangeTrapNumber(amount3.ToString());
        nowtrap = null;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TrapUI1.GetComponent<TrapUI>().OnChooseTrap();
            TrapUI2.GetComponent<TrapUI>().UnChooseTrap();
            TrapUI3.GetComponent<TrapUI>().UnChooseTrap();
            if (amount1 > 0)
            {
                nowtrap = traps[index1 - 1];
            }
            else
            {
                nowtrap = null;
            }
            trap1 = true;
            trap2 = false; 
            trap3 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TrapUI1.GetComponent<TrapUI>().UnChooseTrap();
            TrapUI2.GetComponent<TrapUI>().OnChooseTrap();
            TrapUI3.GetComponent<TrapUI>().UnChooseTrap();
            if (amount2 > 0)
            {
                nowtrap = traps[index2 - 1];
               
            }
            else
            {
                nowtrap = null;
            }
            trap1 = false;
            trap2 = true; 
            trap3 = false;
        }
       else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TrapUI1.GetComponent<TrapUI>().UnChooseTrap();
            TrapUI2.GetComponent<TrapUI>().UnChooseTrap();
            TrapUI3.GetComponent<TrapUI>().OnChooseTrap();
            if (amount3 > 0)
            {
                nowtrap = traps[index3 - 1];
            }
            else
            {
                nowtrap = null;
            }
            trap1 = false;
            trap2 = false; ;
            trap3 = true;
        }

    }
    public void usetrap()
    {
        if (trap1)
        {
            amount1 -= 1;
            TrapUI1.GetComponent<TrapUI>().ChangeTrapNumber(amount1.ToString());

        }
         if (trap2)
        {
            amount2 -= 1;
            TrapUI2.GetComponent<TrapUI>().ChangeTrapNumber(amount2.ToString());
        }
        if (trap3)
        {
            amount3 -= 1;
            TrapUI3.GetComponent<TrapUI>().ChangeTrapNumber(amount3.ToString());
        }
    }

}
