using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class BossAI : MonoBehaviour
{
    public GameObject fireball;
    Rigidbody2D fireballrb;
    public float firerate=5f;
    float nextfire = 0;
    public GameObject player;
    private float distance;
    public float angle;

    public Animator Skill1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            //Skill1.Play("BossAttack1");
            Throwfireball();
        }
    }
    void Throwfireball()
    {
        /*
        Debug.Log("dfdfdfdfdfdfd");
        Quaternion rotation1 = Quaternion.Euler(0, 0, angle);
        Quaternion rotation2 = Quaternion.Euler(0, 0, angle+45.0f);
        Quaternion rotation3 = Quaternion.Euler(0, 0, angle+90.0f);
        GameObject[] fireballs = { Instantiate(fireball, gameObject.transform.position, rotation1), Instantiate(fireball, gameObject.transform.position, rotation2), Instantiate(fireball, gameObject.transform.position, rotation3) };
        for (int i = 0; i < fireballs.Length; i++)
        {
            fireballrb = fireballs[i].GetComponent<Rigidbody2D>();
            fireballrb.velocity = fireballs[i].transform.right * 10;
            Destroy(fireballs[i], 0.5f);
        }
        */
    }
}
