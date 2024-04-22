using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject LeftSpawner;
    public GameObject RightSpawner;
    public GameObject Plane;

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

    void Start()
    {
        StartCoroutine(SpawnRight());
        StartCoroutine(SpawnLeft());
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

    IEnumerator SpawnRight()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(MinWait, MaxWait));
            GameObject Clone = Instantiate(Plane, RightSpawner.transform.position, RightSpawner.transform.rotation);
            Clone.transform.localScale = new Vector3(-Clone.transform.localScale.x, Clone.transform.localScale.y, Clone.transform.localScale.z);
            Clone.GetComponent<Plane>().HorizontalMove = -1;
            Clone.GetComponent<Plane>().Speed = Random.Range(MinSpeed, MaxSpeed);
        }
    }

    IEnumerator SpawnLeft()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(MinWait, MaxWait));
            GameObject Clone = Instantiate(Plane, LeftSpawner.transform.position, LeftSpawner.transform.rotation);
            Clone.GetComponent<Plane>().HorizontalMove = 1;
            Clone.GetComponent<Plane>().Speed = Random.Range(MinSpeed, MaxSpeed);
        } 
    }
}
