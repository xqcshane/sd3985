using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollow : MonoBehaviour
{
    public GameObject player;
    private float distance;
    public float speed;
    public float health;
    public int damage;
    public float sight;
    bool faceright = true;
    bool canMove = true;

    public Animator boss;
    private int skillNumber = 0;

    float startSkill = 3f;
    public float skillRate1 = 10f;
    public Animator Skill1;
    bool doSkilling1 = false;

    public GameObject Skill21;
    public GameObject Skill22;
    public GameObject Skill23;
    public GameObject Skill24;

    public GameObject Skill3;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (Time.time > startSkill)
        {
            if (skillNumber == 0)
            {
                canMove = false;
                doSkilling1 = true;
                startSkill = Time.time + skillRate1;
                Skill1.enabled = true;
                Skill1.Play("BossAttack1");
                StartCoroutine(MyCoroutine1());
            }
            if (skillNumber == 1)
            {
                Skill21.SetActive(true);
                Skill22.SetActive(true);
                Skill23.SetActive(true);
                Skill24.SetActive(true);
                canMove = false;
                doSkilling1 = true;
                startSkill = Time.time + skillRate1;

                Skill21.GetComponent<Animator>().Play("Skill2");
                Skill22.GetComponent<Animator>().Play("Skill21");
                Skill23.GetComponent<Animator>().Play("Skill22");
                Skill24.GetComponent<Animator>().Play("Skill23");
                StartCoroutine(MyCoroutine2());
            }
            if (skillNumber == 2)
            {
                Skill3.SetActive(true);
                canMove = false;
                doSkilling1 = true;
                startSkill = Time.time + skillRate1;

                Skill3.GetComponent<Animator>().Play("Fire1");
                StartCoroutine(MyCoroutine3());
            }

        }
    }

    private IEnumerator MyCoroutine1()
    {
        yield return new WaitForSeconds(2.36666666667f);
        canMove = true;
        doSkilling1 = false;
        Skill1.enabled = false;
        //Skill1.enabled = false;
        skillNumber = 1;
        yield return null;
    }

    private IEnumerator MyCoroutine2()
    {
        yield return new WaitForSeconds(3.833333333333333f);
        canMove = true;
        doSkilling1 = false;
        Skill21.SetActive(false);
        Skill22.SetActive(false);
        Skill23.SetActive(false);
        Skill24.SetActive(false);
        skillNumber = 2;
        yield return null;
    }

    private IEnumerator MyCoroutine3()
    {
        yield return new WaitForSeconds(2.75f);
        canMove = true;
        doSkilling1 = false;
        Skill3.SetActive(false);
        //Skill1.enabled = false;
        skillNumber = 0;
        yield return null;
    }

    private void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (doSkilling1)
        {
            canMove = false;
            boss.Play("Move");
        }


        if (canMove)
        {
            if (distance < sight)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                if (transform.position.x > player.transform.position.x && faceright)
                {
                    Flip();
                }
                else if (transform.position.x < player.transform.position.x && !faceright)
                {
                    Flip();
                }
                //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }

        if (distance < 6)
        {
            canMove = false;
            boss.Play("Attack");
        }
        else
        {
            if (!doSkilling1)
            {
                boss.Play("Idle");
                canMove = true;
            }  
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        faceright = !faceright;
    }
}
