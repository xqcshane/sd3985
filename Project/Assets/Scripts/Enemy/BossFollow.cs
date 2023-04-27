using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollow : MonoBehaviour
{
    public GameObject player;
    private float distance;
    public float speed;
    public float health;
    //public int damageToBoss;
    public float sight;
    bool faceright = true;
    bool canMove = true;

    public Animator boss;
    private int skillNumber = 0;

    public float startSkill;
    public float skillRate1;
    bool doSkilling1 = false;

    public GameObject Skill1;
    
    public GameObject Skill21;
    public GameObject Skill22;
    public GameObject Skill23;
    public GameObject Skill24;

    public GameObject Skill3;

    public GameObject Skill41;
    public GameObject Skill42;
    public GameObject Skill43;
    public GameObject Skill44;
    public GameObject Skill45;
    public GameObject Skill46;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (Time.time > startSkill)
        {
            if (skillNumber == 8)
            {
                Skill1.SetActive(true);
                canMove = false;
                doSkilling1 = true;
                startSkill = Time.time + skillRate1;

                Skill1.GetComponent<Animator>().Play("BossAttack1");
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
            if (skillNumber == 3)
            {
                Skill41.SetActive(true);
                Skill42.SetActive(true);
                Skill43.SetActive(true);
                Skill44.SetActive(true);
                Skill45.SetActive(true);
                Skill46.SetActive(true);
                canMove = false;
                doSkilling1 = true;
                startSkill = Time.time + skillRate1;

                Skill41.GetComponent<Animator>().Play("Skill4");
                Skill42.GetComponent<Animator>().Play("Skill4");
                Skill43.GetComponent<Animator>().Play("Skill4");
                Skill44.GetComponent<Animator>().Play("Skill4");
                Skill45.GetComponent<Animator>().Play("Skill4");
                Skill46.GetComponent<Animator>().Play("Skill4");
                StartCoroutine(MyCoroutine4());
            }

        }
    }

    private IEnumerator MyCoroutine1()
    {
        yield return new WaitForSeconds(2.36666666667f);
        canMove = true;
        doSkilling1 = false;
        Skill1.SetActive(false);
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
        yield return new WaitForSeconds(2.76666666666666666666f);
        canMove = true;
        doSkilling1 = false;
        Skill3.SetActive(false);
        //Skill1.enabled = false;
        skillNumber = 3;
        yield return null;
    }

    private IEnumerator MyCoroutine4()
    {
        yield return new WaitForSeconds(1.5166666666666666666666666666667f);
        canMove = true;
        doSkilling1 = false;
        Skill41.SetActive(false);
        Skill42.SetActive(false);
        Skill43.SetActive(false);
        Skill44.SetActive(false);
        Skill45.SetActive(false);
        Skill46.SetActive(false);
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
            if (!doSkilling1)
            {
                canMove = false;
                boss.Play("Attack");
            }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("dfsfsdfds");
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-5);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("dfsfsdfds");
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-5);
        }
    }

    public void Damaged(float damageToBoss)
    {
        health -= damageToBoss;
        StartCoroutine(MyCoroutine());
        Debug.Log("hitBoss");
    }

    private IEnumerator MyCoroutine()
    {
        animator.Play("Hit");
        canMove = false;
        canMove = false;
        doSkilling1 = true;
        yield return new WaitForSeconds(1f);
        canMove = true;
        doSkilling1 = false;
        //animator.Play("Idle");
        yield return null;
    }
}
