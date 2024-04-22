using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quality : MonoBehaviour
{
    public TextMeshProUGUI Low;
    public TextMeshProUGUI High;

    public GameObject HighTick;
    public GameObject LowTick;

    public int LowQualityIndex = 0;
    public int HighQualityIndex = 1;

    public void LowSettings()
    {
        gameObject.GetComponent<AudioSource>().Play();
        QualitySettings.SetQualityLevel(LowQualityIndex);
        /*Debug.Log("Low Quality");*/
        LowTick.SetActive(true);
        HighTick.SetActive(false);
    }
    public void HightSettings()
    {
        gameObject.GetComponent<AudioSource>().Play();
        QualitySettings.SetQualityLevel(HighQualityIndex);
        /*Debug.Log("High Quality");*/
        LowTick.SetActive(false);
        HighTick.SetActive(true);
    }
    private void OnEnable()
    {
        int QualityLevel = QualitySettings.GetQualityLevel();
        if(QualityLevel == HighQualityIndex)
        {
            LowTick.SetActive(false);
            HighTick.SetActive(true);
        }
        if(QualityLevel == LowQualityIndex)
        {
            LowTick.SetActive(true);
            HighTick.SetActive(false);
        }
    }
}
