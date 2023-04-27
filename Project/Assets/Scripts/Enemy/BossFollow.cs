using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollow : MonoBehaviour
{
    public GameObject player;
    private float distance;
    public float speed;
    public float health;
    private float secondStage;
    private float secondSpeed;

    //public int damageToBoss;
    public float sight;
    bool faceright = true;
    bool canMove = true;

    public Animator boss;
    //private int skillNumber = 0;
    private int skillRange;


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

    public GameObject Skill51;
    public GameObject Skill52;
    public GameObject Skill53;
    public GameObject Skill54;

    public Animator animator;

    private bool goToSecondStage = false;

    private bool hitted = false;

    private void Start()
    {
        secondStage = health / 2;
        skillRange = Random.Range(0, 3);
        secondSpeed = speed * 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Go to second stage
        if (health < secondStage)
        {
            goToSecondStage = true;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (Time.time > startSkill)
        {
            //¶ª»ðÇò
            if (skillRange == 0)
            {
                Skill1.SetActive(true);
                canMove = false;
                doSkilling1 = true;
                startSkill = Time.time + skillRate1;

                Skill1.GetComponent<Animator>().Play("BossAttack1");
                StartCoroutine(MyCoroutine1());
            }
            //ÑÒ½¬Æ½µØ
            if (skillRange == 1)
            {
                Skill3.SetActive(true);
                canMove = false;
                doSkilling1 = true;
                startSkill = Time.time + skillRate1;

                Skill3.GetComponent<Animator>().Play("Fire1");
                StartCoroutine(MyCoroutine3());
            }
            //»ðÑæ»·ÈÆ
            if (skillRange == 2)
            {
                Skill51.SetActive(true);
                Skill52.SetActive(true);
                Skill53.SetActive(true);
                Skill54.SetActive(true);
                canMove = false;
                doSkilling1 = true;
                startSkill = Time.time + skillRate1;

                Skill51.GetComponent<Animator>().Play("Skill5");
                Skill52.GetComponent<Animator>().Play("Skill52");
                Skill53.GetComponent<Animator>().Play("Skill53");
                Skill54.GetComponent<Animator>().Play("Skill54");
                StartCoroutine(MyCoroutine5());
            }
            //»ðÊÖ
            if (skillRange == 3)
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
            //µØÃæ»ðÑæÅçÉä
            if (skillRange == 4)
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
        skillRange = Random.Range(0, 3);
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
        skillRange = Random.Range(3, 5);
        yield return null;
    }

    private IEnumerator MyCoroutine3()
    {
        yield return new WaitForSeconds(2.76666666666666666666f);
        canMove = true;
        doSkilling1 = false;
        Skill3.SetActive(false);
        //Skill1.enabled = false;
        skillRange = Random.Range(0, 3);
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
        skillRange = Random.Range(3, 5);
        yield return null;
    }

    private IEnumerator MyCoroutine5()
    {
        yield return new WaitForSeconds(1.5166666666666666666666666666667f);
        canMove = true;
        doSkilling1 = false;
        Skill51.SetActive(false);
        Skill52.SetActive(false);
        Skill53.SetActive(false);
        Skill54.SetActive(false);
        skillRange = Random.Range(0, 3);
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
            if (!canMove)
            {
                if (!hitted)
                {
                    canMove = false;
                    boss.Play("Move");
                }
            }
        }


        if (canMove)
        {
            if (goToSecondStage)
            {
                if (distance < sight)
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, secondSpeed * Time.deltaTime);
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
            else
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
            //Debug.Log("dfsfsdfds");
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-5);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("dfsfsdfds");
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
        hitted = true;
        canMove = false;
        doSkilling1 = true;
        animator.Play("Hit");
        yield return new WaitForSeconds(1f);
        canMove = true;
        doSkilling1 = false;
        hitted = false;
        //animator.Play("Idle");
        yield return null;
    }
}
