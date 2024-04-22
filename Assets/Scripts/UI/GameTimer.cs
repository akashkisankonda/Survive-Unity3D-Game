using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI TextMesh;
    float time = 0;

    void Update()
    {
        TextMesh.SetText((time += 1 * Time.deltaTime).ToString("0"));
    }
}
