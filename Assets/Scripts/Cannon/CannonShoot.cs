using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    Transform Target;
    Transform Origin;
    GameObject Player;
    public float Time = 1f;

    public Rigidbody2D Ball;
    public Animator animatior;
    public float ShootWait = 3f;

    bool ShootBall = false;


    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Target = GameObject.FindWithTag("Player").transform;
        Origin = GameObject.Find("Origin").transform;

     

        StartCoroutine(Shoot());
    }
    Vector3 CalculateVelocity(Vector3 Target, Vector3 Origin, float Time)
    {
        Vector3 Distance = Target - Origin;
        Vector3 Distancexz = Distance;
        Distancexz.y = 0f;

        float Sy = Distance.y;
        float Sxy = Distancexz.magnitude;

        float Vxz = Sxy / Time;
        float Vy = Sy / Time + 0.5f * Mathf.Abs(Physics.gravity.y) * Time;

        Vector3 Result = Distancexz.normalized;
        Result *= Vxz;
        Result.y = Vy;

        return Result;
    }

    IEnumerator Shoot()
    {
        while (true && !Player.GetComponent<Health>().PlayerDied)
        {
            yield return new WaitForSeconds(ShootWait);
            if (ShootBall)
            {
                    Vector3 Vo = CalculateVelocity(Target.position, Origin.position, Time);
                    animatior.SetTrigger("Shoot");
                    Rigidbody2D Obj = Instantiate(Ball, Origin.position, Origin.rotation);
                    Obj.velocity = Vo;
            }
            
        }


    }

    private void Update()
    {
        if(Mathf.Abs(Target.position.x - transform.position.x) > 3)
        {
            Vector3 Vo = CalculateVelocity(Target.position, Origin.position, Time);
            float angle = Mathf.Atan2(Vo.y, Vo.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            ShootBall = true;
        }
        else
        {
            ShootBall = false;
        }

        
    }
}
