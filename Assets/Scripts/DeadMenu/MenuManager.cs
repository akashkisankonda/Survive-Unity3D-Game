using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Animator ani;
    public GameObject Blocker;
    private GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        

        if (Player)
        {
            if (Player.GetComponent<Health>().PlayerDied)
            {
                ani.SetTrigger("AppearMenu");
                Time.timeScale = 0;
                Blocker.SetActive(true);
            }
        }
    }

}
