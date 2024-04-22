using DitzeGames.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeCollision : MonoBehaviour
{
    public GameObject ExplosionEffect;
    GameObject Player;

    public float DamageRange = 4f;
    public LayerMask PlayerLayer;
    public LayerMask EnemiesLayer;
    public float DamageToPlayer = 30f;
    public float AudioRange = 12f;

    private AudioSource PlayerHurtAudio;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerHurtAudio = GameObject.FindWithTag("PlayerHurt").GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) < AudioRange)
        {
            gameObject.GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameObject Obj = Instantiate(ExplosionEffect, transform.position, transform.rotation);

            if (Vector2.Distance(Player.transform.position, transform.position) < 25)
            {
                Obj.GetComponent<AudioSource>().enabled = true;
            }
            else
            {
                Obj.GetComponent<AudioSource>().enabled = false;
            }


            Obj.transform.SetParent(null);
            Player.GetComponent<ManageAfterEffects>().DestroyEffect(Obj);
            //Damage to Player
            Collider2D PlayerInRange = Physics2D.OverlapCircle(Obj.transform.position, DamageRange, PlayerLayer);
            if (PlayerInRange)
            {
                Player.GetComponent<Health>().PlayerHealth -= DamageToPlayer;
                PlayerHurtAudio.Play();
            }
            //kill Enemies
            Collider2D[] EnemiesInRange = Physics2D.OverlapCircleAll(Obj.transform.position, DamageRange, EnemiesLayer);
            foreach (Collider2D Enemies in EnemiesInRange)
            {
                Enemies.GetComponent<Enemies>().IsDead = true;
            }
            if (Vector3.Distance(Player.transform.position, transform.position) < 20)
            {
                CameraEffects.ShakeOnce(1f, 10);
            }
            Destroy(gameObject);
        }
    }
}
