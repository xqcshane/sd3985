using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 newpos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("haha");
        if (collision.gameObject.CompareTag("Player")){
            /* if (collision.GetComponent<NonetworkMove>().inpassage == false)
             {
                 collision.gameObject.GetComponent<NonetworkMove>().inpassage =true;
                 collision.gameObject.GetComponent<NonetworkMove>().speed += 0.2f;
                 collision.gameObject.GetComponent<NonetworkAim>().enabled = false;
             }
             else if(collision.GetComponent<NonetworkMove>().inpassage == true)
             {
                 collision.gameObject.GetComponent<NonetworkMove>().inpassage = false;
                 collision.gameObject.GetComponent<NonetworkMove>().speed -= 0.2f;
                 collision.gameObject.GetComponent<NonetworkAim>().enabled = true;
                 GameObject[] allenemy=GameObject.FindGameObjectsWithTag("Enemy");
                 for(int i = 0; i < allenemy.Length; i++)
                 {
                     allenemy[i].GetComponent<NonetworkEnemy>().enterpassage = false;
                 }
             }*/
            collision.gameObject.transform.position = newpos;
            GameObject[] allenemy = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < allenemy.Length; i++)
            {
                allenemy[i].GetComponent<NonetworkEnemy>().enterpassage = false;
            }
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<NonetworkEnemy>().enterpassage = true;
        }
    }
}
