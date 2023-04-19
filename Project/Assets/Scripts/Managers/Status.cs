using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Status : MonoBehaviour
{
    public int status;
    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

    }
}
