using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManage : MonoBehaviour
{
    public Animator ani;
    public Animator homeani;
    public GameObject Blocker;

    public GameObject PauseBlock;
    public GameObject DeadBlock;



    public void onPause()
    {
        gameObject.GetComponent<AudioSource>().Play();
        /*Debug.Log("Clicked");*/
        PauseBlock.SetActive(false);
        Blocker.SetActive(true);
        Time.timeScale = 0;
        ani.SetTrigger("AppearSettiigs");
    }

    public void OnResume()
    {
        gameObject.GetComponent<AudioSource>().Play();
        PauseBlock.SetActive(true);
        ani.SetTrigger("DisappearSettings");
        Blocker.SetActive(false);
        Time.timeScale = 1;

    }

    public void OnRestart()
    {
        gameObject.GetComponent<AudioSource>().Play();
        homeani.SetTrigger("PlayTrans");
        PauseBlock.SetActive(true);
        DeadBlock.SetActive(true);
    }

    public void OnMainMenu()
    {
        PauseBlock.SetActive(true);
        DeadBlock.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
