using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EenemySpawner : MonoBehaviour
{
    public Transform LeftSpawner;
    public Transform RightSpawner;
    public GameObject[] Enemies;

    private float MinWait = 0 ;
    private float MaxWait = 60 ;

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
            GameObject LeftClone = Instantiate(Enemies[Random.Range(0, 3)], LeftSpawner.position, LeftSpawner.rotation);
            LeftClone.GetComponent<Enemies>().Speed = Random.Range(MinSpeed, MaxSpeed);
        }
    }

    IEnumerator RightSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(MinWait, MaxWait));
            GameObject EnemyClone = Instantiate(Enemies[Random.Range(0, 3)], RightSpawner.position, RightSpawner.rotation);
            EnemyClone.transform.localScale = new Vector3(-EnemyClone.transform.localScale.x, EnemyClone.transform.localScale.y, EnemyClone.transform.localScale.z);
            EnemyClone.GetComponent<Enemies>().HorizontalMove = -1;
            EnemyClone.GetComponent<Enemies>().Speed = Random.Range(MinSpeed, MaxSpeed);
        }
    }



}
