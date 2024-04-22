using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float PlayerHealth = 100f;
    public Rigidbody2D rb;
    public Animator animator;
    private UIHealth uihealth;
 

    public bool PlayerDied = false;

    public bool DamageResistance = false;
    public float TempPlayerHealth;

    public float CannonBallDamage = 20f;

    private AudioSource PlayerHurtAudio;

    private void Start()
    {
        uihealth = GameObject.Find("Border").GetComponent<UIHealth>();

        PlayerHurtAudio = GameObject.FindWithTag("PlayerHurt").GetComponent<AudioSource>();
    }


    private void Update()
    {
        if(DamageResistance == true && PlayerHealth < TempPlayerHealth)
        {
            PlayerHealth = TempPlayerHealth;
        }


        if(PlayerHealth > 100)
        {
            PlayerHealth = 100;
        }
        if (PlayerHealth < 0 && PlayerDied == false)
        {
            Die();
        }





        uihealth.SetHealth(PlayerHealth); 

    }
    
        
    

    void Die()
    {
        PlayerDied = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
        animator.SetBool("IsDead", true);
        this.GetComponent<Collider2D>().enabled = false;
        rb.velocity = Vector2.zero;
        gameObject.GetComponent<NinjaMovements>().enabled = false;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
           /* Debug.Log("Collided");*/
            PlayerHealth -= CannonBallDamage;
            PlayerHurtAudio.Play();
        }
    }



}
