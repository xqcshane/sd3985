using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapData : MonoBehaviour
{
    public int skillindex1;
    public int skillindex2;
    public int skillindex3;
    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
