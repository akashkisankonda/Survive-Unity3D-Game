using DitzeGames.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public GameObject ExplosionEffect;
    GameObject Player;

    public float DamageRange = 1.5f;
    public LayerMask PlayerLayer;
    public LayerMask EnemiesLayer;

    public float CannonBallDamage = 20f;


    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
  
            GameObject Obj = Instantiate(ExplosionEffect, transform.position, transform.rotation);
            Obj.transform.SetParent(null);
            Player.GetComponent<ManageAfterEffects>().DestroyEffect(Obj);

/*            Collider2D PlayerInRange = Physics2D.OverlapCircle(Obj.transform.position, DamageRange, PlayerLayer);
            if (PlayerInRange)
            {
                Player.GetComponent<Health>().PlayerHealth -= 20;
            }
            //kill Enemies
            Collider2D[] EnemiesInRange = Physics2D.OverlapCircleAll(Obj.transform.position, DamageRange, EnemiesLayer);
            foreach (Collider2D Enemies in EnemiesInRange)
            {
                Enemies.GetComponent<Enemies>().IsDead = true;
            }*/

            if (Vector3.Distance(Player.transform.position,transform.position) < 5)
            {
                CameraEffects.ShakeOnce(.2f, 10);
            }
            Destroy(gameObject);
        }
    }
  

}
