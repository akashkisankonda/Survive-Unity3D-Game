using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneTrans : MonoBehaviour
{
    public Animator ani;


    private void Update()
    {

    }
    public void SwitchScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }
}
