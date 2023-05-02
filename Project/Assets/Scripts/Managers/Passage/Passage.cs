using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{
    // Start is called before the first frame update
    //public Vector3 newpos;
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
            collision.GetComponent<PlayerMove>().speed = 1.0f;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<NonetworkEnemy>().enterpassage = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("haha");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMove>().speed = 0.5f;
            collision.gameObject.GetComponent<NonetworkEnemy>().enterpassage = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<NonetworkEnemy>().enterpassage = false;
        }
    }
}
