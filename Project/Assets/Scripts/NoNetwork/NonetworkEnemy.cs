using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonetworkEnemy : MonoBehaviour
{
    GameObject player;
    private float distance;
    public float speed;
    public float health;
    public float damage;
    public float sight;
    bool faceright = true;
    public bool enterpassage = false;
    bool dead = false;
    public Animator animator;

    bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(MyCoroutine());
        }
    }
    
    private IEnumerator MyCoroutine()
    {
        Debug.Log("globin dead");
        animator.Play("globin_death");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        yield return null;
    }
    

    private void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (enterpassage == true)
        {
            animator.SetBool("run_right", false);
            animator.SetBool("run_left", false);
            animator.SetBool("outOfSight", true);
        }
        else if (enterpassage == false)
        {
            if (canMove)
            {
                if (distance < sight)
                {

                    animator.SetBool("outOfSight", false);
                    if (System.Math.Abs(transform.position.x - player.transform.position.x) > 2 && health > 0)
                    {

                        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

                        if (transform.position.x > player.transform.position.x && faceright)
                        {
                            animator.SetBool("run_right", true);
                            Flip();
                        }
                        else if (transform.position.x < player.transform.position.x && !faceright)
                        {
                            animator.SetBool("run_left", true);
                            Flip();
                        }
                    }

                    //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
                }
                else
                {
                    animator.SetBool("run_right", false);
                    animator.SetBool("run_left", false);
                    animator.SetBool("outOfSight", true);
                }
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
    //emyattack
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MyCoroutine3());
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-5);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MyCoroutine3());
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-5);
        }
    }


    private IEnumerator MyCoroutine3()
    {
        Debug.Log("globin attack");
        animator.Play("globin_attack");
        canMove = false;
        yield return new WaitForSeconds(1f);
        canMove = true;
        animator.Play("globin_idle");
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
        animator.Play("globin_hit");
        canMove = false;
        yield return new WaitForSeconds(1f);
        canMove = true;
        animator.Play("globin_idle");
        yield return null;
    }
}
