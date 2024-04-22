using DitzeGames.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemies : MonoBehaviour
{
    public LayerMask PlayerLayer;
    public Transform AttackPoint;
    public float AttackRange;
    public Animator animator;
    private Rigidbody2D rb;
    Collider2D Player;

    bool OnGround = false;
    bool PlayerInRange = false;
    public bool IsDead = false; 


    public float enemyDamage = 50f;

    public float HorizontalMove = 1;
    public float Speed = 3f;

    private AudioSource PlayerHurtAudio;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.gravityScale = 100;

        PlayerHurtAudio = GameObject.FindWithTag("PlayerHurt").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (IsDead)
        {
            animator.SetTrigger("Dead");
            HorizontalMove = 0;
            StartCoroutine(Died());
        }

        Player = Physics2D.OverlapCircle(AttackPoint.position, AttackRange, PlayerLayer);
        if (Player != null && IsDead == false)
        {
            animator.SetBool("PlayerInRange", true);
            PlayerInRange = true;
        }
        else
        {
            animator.SetBool("PlayerInRange", false);
            PlayerInRange = false;
        }
        

        
    }
    void FixedUpdate()
    {
        if(PlayerInRange == false)
        {
            rb.velocity = new Vector3(HorizontalMove * Speed, 0, 0);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }


    public void Attack()
    {
        if (PlayerInRange && Player.GetComponent<Health>().PlayerHealth >= 0)
        {
            gameObject.GetComponent<AudioSource>().Play();
            Player.GetComponent<Health>().PlayerHealth -= enemyDamage;
            PlayerHurtAudio.Play();
            CameraEffects.ShakeOnce(.1f, 12);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(OnGround == false)
        {
            animator.SetBool("OnGround", true);
            OnGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyWall")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Ball")
        {
            IsDead = true;
        }
    }
    IEnumerator Died()
    {
        yield return new WaitForSeconds(Random.Range(10, 30));
        Destroy(gameObject);
    }




}
