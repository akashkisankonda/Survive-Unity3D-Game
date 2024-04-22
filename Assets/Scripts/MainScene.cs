using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public Animator ani;
    public GameObject NinjaB;
    public GameObject NinjaG;
    public GameObject Fader;

    public GameObject SelectionMenu;
    public GameObject DifficultyMenu;

    public AudioSource SurviveAudio;
    void Start()
    {
        Time.timeScale = 0;
        ani.SetTrigger("SelectionFadeIn");

        Application.targetFrameRate = 60;
    }




    public void OnNinjaB()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Instantiate(NinjaB, Vector3.zero, transform.rotation);
        ani.SetTrigger("SelectionFadeIn");
        DifficultyMenu.SetActive(true);
        Destroy(SelectionMenu);
    }
    public void OnNinjaG()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Instantiate(NinjaG, Vector3.zero, transform.rotation);
        DifficultyMenu.SetActive(true);
        Destroy(SelectionMenu);
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SurviveAudioo()
    {
        SurviveAudio.Play();
    }

}
