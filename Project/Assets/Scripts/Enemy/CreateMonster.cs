using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    // Start is called before the first frame update
    public int amount;
    public GameObject enemy;
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
