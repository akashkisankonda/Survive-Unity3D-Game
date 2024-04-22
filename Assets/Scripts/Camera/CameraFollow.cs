using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform Target;
    public float SmoothSpeed = 100f;
    private Vector3 velocity = Vector3.zero;
    public float Clampvalueleft = -59.50f;
    public float Clampvalueright = 59.50f;


    void Update()
    {

        if (Time.timeScale > 0) 
        {
            Target = GameObject.FindWithTag("Player").transform;
            if (Target)
            {
                Vector3 DesiredPosition = new Vector3(Target.position.x, transform.position.y, transform.position.z);
                Vector3 SmoothPositin = Vector3.SmoothDamp(transform.position, DesiredPosition, ref velocity, SmoothSpeed * Time.unscaledDeltaTime);
                transform.position = new Vector3(Mathf.Clamp(SmoothPositin.x, Clampvalueleft, Clampvalueright), SmoothPositin.y, SmoothPositin.z);

            }
        }
        
    }
}
