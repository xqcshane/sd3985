using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pickup : MonoBehaviour
{
    public GameObject Staff1;
    public GameObject Staff2;
    public GameObject Staff3;
    public GameObject Staff4;
    public int index = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("yi");
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("yi2");
            if (collision.GetComponent<PlayerAim>().currentweaponindex==0)
            {
              Instantiate(Staff1, transform.position, transform.rotation);
            }
            else if (collision.GetComponent<PlayerAim>().currentweaponindex == 1)
            {
              Instantiate(Staff2, transform.position, transform.rotation);
            }
            else if (collision.GetComponent<PlayerAim>().currentweaponindex == 2)
            {
                Instantiate(Staff3, transform.position, transform.rotation);
            }
            else if (collision.GetComponent<PlayerAim>().currentweaponindex == 3)
            {
               Instantiate(Staff4, transform.position, transform.rotation);
            }
            collision.GetComponent<PlayerAim>().currentweaponindex = index;
            Destroy(gameObject);
        }
    }
}
