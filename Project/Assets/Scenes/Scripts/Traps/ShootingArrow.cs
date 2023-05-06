using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootingArrow : MonoBehaviour
{
    public GameObject justArrowPrefab;
    Rigidbody2D rigidbody2d;
    public Vector2 lookDirection = new Vector2(1, 0);

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        StartCoroutine(MyCoroutine());
    }

    void RepeatMyCoroutine()
    {
        StartCoroutine(MyCoroutine());
    }

    private IEnumerator MyCoroutine()
    {
        Launch();
        yield return new WaitForSeconds(0.66667f);
        RepeatMyCoroutine();
        yield return null;
    }

    void Update()
    {

    }

    void Launch()
    {
        GameObject justArrow = PhotonNetwork.Instantiate("Justarrow", rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Arrow arrow = justArrow.GetComponent<Arrow>();
        arrow.Launch(lookDirection, 300);
    }
}
