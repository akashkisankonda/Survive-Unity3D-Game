using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMovements : MonoBehaviour
{
    public CharacterController2D Controller;
    private Joystick Joystick;
    public Animator animator;
    float HorizontalMove = 0f;
    public float RunSpeed = 40f;
    bool Jump = false;

    private void Start()
    {
        GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Interpolate;
        Joystick = GameObject.FindWithTag("Joystick").GetComponent<Joystick>();
    }

    void Update()
    {
        if(Joystick.Horizontal >= .2f)
        {
            HorizontalMove = RunSpeed;
        }else if(Joystick.Horizontal <= -.2f)
        {
            HorizontalMove = -RunSpeed;
        }
        else
        {
            HorizontalMove = 0;
        }

        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));


        if(Input.touchCount > 1)
        {
            Touch touch = Input.GetTouch(1);
            if (touch.phase == TouchPhase.Began)
            {
                Jump = true;
                animator.SetBool("IsJumping", true);
            }
        }
        
    }

    private void FixedUpdate()
    {
        Controller.Move(HorizontalMove * Time.fixedUnscaledDeltaTime , false, Jump);
        Jump = false;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            animator.SetBool("IsJumping", false);
        }
    }

    public void OnJump()
    {
        gameObject.GetComponent<AudioSource>().Play();

    }
}
