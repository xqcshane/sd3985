using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public int score;
    public bool death;
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

   
}
