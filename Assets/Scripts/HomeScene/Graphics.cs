using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphics : MonoBehaviour
{
    public Animator ani;
    public Animator Menuani;
    public GameObject SettingsBlocker;
    public GameObject MenuBlocker;

    public void BackBtnClick()
    {
        gameObject.GetComponent<AudioSource>().Play();
        ani.SetTrigger("DisappearSettings");
        Menuani.SetTrigger("AppearMenu");
        SettingsBlocker.SetActive(true);
        MenuBlocker.SetActive(false);
    }






}
