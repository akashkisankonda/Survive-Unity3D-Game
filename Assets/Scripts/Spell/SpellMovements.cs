using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMovements : MonoBehaviour
{
    public float Speed = 15;
    public float HorizontalMove = 1f;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(HorizontalMove * Speed, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyWall")
        {
            Destroy(gameObject);
        }
    }
}
