using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public Animator ani;
    public Animator Settingsani;
    public GameObject MenuBlocker;
    public GameObject SettingsBlocker;
    public GameObject HomeParticles;


    void OnEnable()
    {
        Time.timeScale = 1;
        ani.SetTrigger("AppearMenu");

    }

    public void SettingsBtnClick()
    {
        gameObject.GetComponent<AudioSource>().Play();
        ani.SetTrigger("DisappearMenu");
        Settingsani.SetTrigger("AppearSettiigs");
        MenuBlocker.SetActive(true);
        SettingsBlocker.SetActive(false);
    }

    public void OnExitBtnClick()
    {
        Application.Quit();
    }
}
