using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{

    public GameObject[] LeftSpells;
    public GameObject[] RightSpells;

    public Transform LeftSpawner;
    public Transform RightSpawner;

    private float MinWait = 0;
    private float MaxWait = 60;

    private float MinSpeed = 10;
    private float MaxSpeed = 25;



    public float EasyMinWait;
    public float EasyMaxWait;
    public float NormalMinWait;
    public float NormalMaxWait;
    public float HardMinWait;
    public float HardMaxWait;

    public float EasyMinSpeed;
    public float EasyMaxSpeed;
    public float NormalMinSpeed;
    public float NormalMaxSpeed;
    public float HardMinSpeed;
    public float HardMaxSpeed;

    private void Start()
    {
        StartCoroutine(LeftSpawn());
        StartCoroutine(RightSpawn());
    }

    public void OnEasy()
    {
        MinWait = EasyMinWait;
        MaxWait = EasyMaxWait;

        MinSpeed = EasyMinSpeed;
        MaxSpeed = EasyMaxSpeed;
    }
    public void OnNormal()
    {
        MinWait = NormalMinWait;
        MaxWait = NormalMaxWait;

        MinSpeed = NormalMinSpeed;
        MaxSpeed = NormalMaxSpeed;
    }

    public void OnHard()
    {
        MinWait = HardMinWait;
        MaxWait = HardMaxWait;

        MinSpeed = HardMinSpeed;
        MaxSpeed = HardMaxSpeed;
    }

    IEnumerator LeftSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(MinWait, MaxWait));
            GameObject Clone = Instantiate(LeftSpells[Random.Range(0,2)], LeftSpawner.position, LeftSpawner.rotation);
            Clone.GetComponent<SpellMovements>().Speed = Random.Range(MinSpeed, MaxSpeed);
        }
    }

    IEnumerator RightSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(MinWait, MaxWait));
            GameObject Clone = Instantiate(RightSpells[Random.Range(0, 2)], RightSpawner.position, RightSpawner.rotation);
            Clone.GetComponent<SpellMovements>().HorizontalMove = -1;
            Clone.GetComponent<SpellMovements>().Speed = Random.Range(MinSpeed, MaxSpeed);
        }
    }
}
