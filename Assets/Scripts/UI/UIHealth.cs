using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Slider slider;
    
    public void SetHealth(float Health)
    {
        slider.value = Health ;
    }

}
