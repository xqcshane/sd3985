using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBoss : MonoBehaviour
{
  public void stronge()
    {
        this.GetComponent<BossFollow>().health = this.GetComponent<BossFollow>().health * 2;
        this.GetComponent<BossFollow>().speed=this.GetComponent<BossFollow>().speed +=0.5f;
    }
}
