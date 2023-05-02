using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class NoNetworkMushroom : MonoBehaviour
{
    GameObject player;
    private float distance;
    public float speed;
    public float health;
    public float damage;
    public float sight;
    bool faceright = true;
    public bool enterpassage = false;
    bool isaddscore = false;
    public Animator animator;

    bool canMove = true;
    bool Bonus = false;
    public GameObject score;
    public int status;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        status = GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().status;
        score = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (!isaddscore)
            {
                score.GetComponent<ScoreController>().addScore(20);
                isaddscore = true;
            }
            StartCoroutine(MyCoroutine());

        }
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (enterpassage == true)
        {
            animator.SetBool("attack_flip", false);
            animator.SetBool("death", false);
            animator.SetBool("attack", false);
            animator.SetBool("hit", false);
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("outOfSight", true);
            if (transform.position.x > player.transform.position.x && faceright)
            {
                animator.SetBool("attack_flip", false);
                animator.SetBool("death", false);
                animator.SetBool("attack", false);
                animator.SetBool("hit", false);
                animator.SetBool("right", true);
                animator.SetBool("left", false);
                animator.SetBool("outOfSight", false);
                //Flip();
            }
            else if (transform.position.x < player.transform.position.x && !faceright)
            {
                animator.SetBool("attack_flip", false);
                animator.SetBool("death", false);
                animator.SetBool("attack", false);
                animator.SetBool("hit", false);
                animator.SetBool("right", false);
                animator.SetBool("left", true);
                animator.SetBool("outOfSight", false);
                //Flip();
            }
        }
        else if (enterpassage == false)
        {
            if (canMove)
            {

                if (distance < sight)
                {
                    animator.SetBool("attack_flip", false);
                    animator.SetBool("death", false);
                    //animator.SetBool("attack", false);
                    animator.SetBool("hit", false);
                    animator.SetBool("right", false);
                    animator.SetBool("left", false);
                    animator.SetBool("outOfSight", false);
                    if (health > 0)
                    {

                        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                        if (transform.position.x > player.transform.position.x)
                        {
                            animator.SetBool("attack_flip", false);
                            animator.SetBool("death", false);
                            animator.SetBool("attack", false);
                            animator.SetBool("hit", false);
                            animator.SetBool("right", false);
                            animator.SetBool("left", true);
                            animator.SetBool("outOfSight", false);
                        }
                        else if (transform.position.x < player.transform.position.x)
                        {
                            animator.SetBool("attack_flip", false);
                            animator.SetBool("death", false);
                            animator.SetBool("attack", false);
                            animator.SetBool("hit", false);
                            animator.SetBool("right", true);
                            animator.SetBool("left", false);
                            animator.SetBool("outOfSight", false);

                        }
                        if (transform.position.x > player.transform.position.x && faceright)
                        {

                            // Flip();


                        }
                        else if (transform.position.x < player.transform.position.x && !faceright)
                        {

                            // Flip();


                        }


                    }

                    //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
                }
                else if (distance > sight)
                {
                    animator.SetBool("attack_flip", false);
                    animator.SetBool("death", false);
                    animator.SetBool("attack", false);
                    animator.SetBool("hit", false);
                    animator.SetBool("right", false);
                    animator.SetBool("left", false);
                    animator.SetBool("outOfSight", true);
                    /* if (transform.position.x > player.transform.position.x && faceright)
                     {
                         Flip();
                     }
                     else if (transform.position.x < player.transform.position.x && !faceright)
                     {
                         Flip();
                     }*/
                }
            }
        }
    }

    private IEnumerator MyCoroutine()
    {
        animator.SetBool("attack_flip", false);
        animator.SetBool("death", true);
        animator.SetBool("attack", false);
        animator.SetBool("hit", false);
        animator.SetBool("right", false);
        animator.SetBool("left", false);
        animator.SetBool("outOfSight", false);
        yield return new WaitForSeconds(1f);
        PhotonNetwork.Destroy(gameObject);
        yield return null;
    }


    private void FixedUpdate()
    {

    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        faceright = !faceright;
    }
    //emyattack
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("11");
            StartCoroutine(MyCoroutine3());
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-5);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!animator.GetBool("attack") && !animator.GetBool("attack_flip"))
            {
                Debug.Log("2");
                StartCoroutine(MyCoroutine3());
                collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-5);
            }
        }
    }


    private IEnumerator MyCoroutine3()
    {
        //Debug.Log("globin attack");
        //animator.Play("globin_attack");
        if (transform.position.x > player.transform.position.x)
        {
            animator.SetBool("attack_flip", true);
            animator.SetBool("death", false);
            animator.SetBool("attack", false);
            animator.SetBool("hit", false);
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("outOfSight", false);
        }
        if (transform.position.x < player.transform.position.x)
        {
            animator.SetBool("attack_flip", false);
            animator.SetBool("death", false);
            animator.SetBool("attack", true);
            animator.SetBool("hit", false);
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("outOfSight", false);
        }
        canMove = false;
        yield return new WaitForSeconds(1f);
        canMove = true;
        animator.SetBool("attack_flip", false);
        animator.SetBool("death", false);
        animator.SetBool("attack", false);
        animator.SetBool("hit", false);
        animator.SetBool("right", false);
        animator.SetBool("left", false);
        animator.SetBool("outOfSight", false); ;
        //animator.Play("globin_idle");
        yield return null;
    }

    public void Damaged(float damage)
    {
        health -= damage;
        //animator.Play("globin_hit");
        StartCoroutine(MyCoroutine2());
    }

    private IEnumerator MyCoroutine2()
    {
        Debug.Log("globin hit");
        //animator.Play("globin_hit");
        animator.SetBool("attack_flip", false);
        animator.SetBool("death", false);
        animator.SetBool("attack", false);
        animator.SetBool("hit", true);
        animator.SetBool("right", false);
        animator.SetBool("left", false);
        animator.SetBool("outOfSight", false);
        canMove = false;
        yield return new WaitForSeconds(1f);
        canMove = true;
        animator.SetBool("attack_flip", false);
        animator.SetBool("death", false);
        animator.SetBool("attack", false);
        animator.SetBool("hit", false);
        animator.SetBool("right", false);
        animator.SetBool("left", false);
        animator.SetBool("outOfSight", false);
        //animator.Play("globin_idle");
        yield return null;
    }
}
