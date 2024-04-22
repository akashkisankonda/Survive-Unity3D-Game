using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public Animator ani;
    public GameObject Self;

    private GameObject Player;

    public void OnHardSelect()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Player = GameObject.FindWithTag("Player");
        /*Debug.Log("Hard Selected");*/
        ani.SetTrigger("Main");
        Time.timeScale = 1;
        Player.GetComponent<EenemySpawner>().OnHard();
        Player.GetComponent<SpellSpawner>().OnHard();
        Player.GetComponent<PlaneSpawner>().OnHard();
        Player.GetComponent<CannonSpawner>().OnHard();


        Destroy(Self);
    }

    public void OnEasySelect()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Player = GameObject.FindWithTag("Player");
        /*Debug.Log("Easy Selected");*/
        ani.SetTrigger("Main");
        Time.timeScale = 1;
        Player.GetComponent<EenemySpawner>().OnEasy();
        Player.GetComponent<SpellSpawner>().OnEasy();
        Player.GetComponent<PlaneSpawner>().OnEasy();
        Player.GetComponent<CannonSpawner>().OnEasy();


        Destroy(Self);
    }
    public void OnNormalSelect()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Player = GameObject.FindWithTag("Player");
        /*Debug.Log("Normal Selected");*/
        ani.SetTrigger("Main");
        Time.timeScale = 1;
        Player.GetComponent<EenemySpawner>().OnNormal();
        Player.GetComponent<SpellSpawner>().OnNormal();
        Player.GetComponent<PlaneSpawner>().OnNormal();
        Player.GetComponent<CannonSpawner>().OnNormal();


        Destroy(Self);
    }
}
