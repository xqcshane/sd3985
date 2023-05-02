using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Photon.Pun;

public class Pickup : MonoBehaviour
{
    public GameObject Staff1;
    GameObject player;
    private float distance;
    public GameObject Staff2;
    public GameObject Staff3;
    public GameObject Staff4;
    public int index = 1;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
    distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 10)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
           
            Debug.Log("yi2");
            if (collision.GetComponent<PlayerAim>().currentweaponindex==0)
            {
                PhotonNetwork.Instantiate("normal", transform.position, transform.rotation);
            }
            else if (collision.GetComponent<PlayerAim>().currentweaponindex == 1)
            {
                PhotonNetwork.Instantiate("shotgun", transform.position, transform.rotation);
            }
            else if (collision.GetComponent<PlayerAim>().currentweaponindex == 2)
            {
                PhotonNetwork.Instantiate("bomb", transform.position, transform.rotation);
            }
            else if (collision.GetComponent<PlayerAim>().currentweaponindex == 3)
            {
                PhotonNetwork.Instantiate("fast", transform.position, transform.rotation);
            }
            collision.GetComponent<PlayerAim>().currentweaponindex = index;
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
