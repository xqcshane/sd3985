using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootingArrow : MonoBehaviour
{
    public GameObject justArrowPrefab;
    Rigidbody2D rigidbody2d;
    public Vector2 lookDirection = new Vector2(1, 0);
    private int PR;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        PR = GameObject.Find("Controller").GetComponent<Controller>().PlayerRole;
        StartCoroutine(MyCoroutine());
    }

    void RepeatMyCoroutine()
    {
        StartCoroutine(MyCoroutine());
    }

    private IEnumerator MyCoroutine()
    {
        Launch();
        yield return new WaitForSeconds(1.2f);
        RepeatMyCoroutine();
        yield return null;
    }

    void Update()
    {

    }

    void Launch()
    {
        if (PR == 0)
        {
            Vector2 newPosition = rigidbody2d.position + Vector2.up * 0.5f;
            GameObject justArrow = PhotonNetwork.Instantiate("Justarrow", new Vector3(newPosition.x, newPosition.y, 0.0f), Quaternion.identity);

            Arrow arrow = justArrow.GetComponent<Arrow>();
            arrow.Launch(lookDirection, -10.0f);
        }
    }
}
