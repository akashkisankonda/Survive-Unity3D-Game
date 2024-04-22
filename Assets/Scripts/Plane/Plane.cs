using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float HorizontalMove = 1f;
    public float Speed = 1f;
    public Rigidbody2D rb;

    public GameObject Nuke;

    public float AudioRange = 50f;
    private GameObject Player;
    void Start()
    {
        StartCoroutine(ThrowNuke());
        Player = GameObject.FindWithTag("Player");
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector3(HorizontalMove * Speed, 0, 0);
        if(Vector2.Distance(Player.transform.position, transform.position) < AudioRange)
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
        if(collision.gameObject.tag == "EnemyWall")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ThrowNuke()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            GameObject Clone = Instantiate(Nuke, transform.position, transform.rotation);
            if(HorizontalMove == -1)
            {
                Clone.transform.localScale = new Vector3(-Clone.transform.localScale.x, Clone.transform.localScale.y, Clone.transform.localScale.z);
            }

        }
        

    }
}
