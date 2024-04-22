using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellTimers : MonoBehaviour
{
    public float time;
    TextMeshProUGUI TextMesh;

    private void Start()
    {
        TextMesh = gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if(time >= 0)
        {
            time -= 1 * Time.deltaTime;
            TextMesh.text = time.ToString("0");
        }
    }
}
