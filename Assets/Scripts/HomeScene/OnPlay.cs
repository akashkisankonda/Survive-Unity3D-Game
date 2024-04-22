using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlay : MonoBehaviour
{
    public Animator ani;
    public GameObject MenuBlocker;
    public GameObject HomeParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayClick()
    {
        gameObject.GetComponent<AudioSource>().Play();
        MenuBlocker.SetActive(true);
        HomeParticles.SetActive(false);
        ani.SetTrigger("PlayTrans");
    }

}
