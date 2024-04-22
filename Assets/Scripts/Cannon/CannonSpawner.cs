using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSpawner : MonoBehaviour
{
    public GameObject Cannon;
    public GameObject SmokeEffect;
    GameObject Player;

    private float MinWait = 0;
    private float MaxWait = 60;

    public float EasyMinWait;
    public float EasyMaxWait;
    public float NormalMinWait;
    public float NormalMaxWait;
    public float HardMinWait;
    public float HardMaxWait;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        StartCoroutine(Spawn());
    }

    public void OnEasy()
    {
        MinWait = EasyMinWait;
        MaxWait = EasyMaxWait;


    }
    public void OnNormal()
    {
        MinWait = NormalMinWait;
        MaxWait = NormalMaxWait;


    }

    public void OnHard()
    {
        MinWait = HardMinWait;
        MaxWait = HardMaxWait;

    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(MinWait, MaxWait));
        
        GameObject CannonClone = Instantiate(Cannon, new Vector3(Random.Range(transform.position.x - 10, transform.position.x + 10), 2.20f, 0), transform.rotation);
        GameObject SmokeClone = Instantiate(SmokeEffect, CannonClone.transform.position, CannonClone.transform.rotation);

        Player.GetComponent<ManageAfterEffects>().DestroyEffect(SmokeClone);

        StartCoroutine(DestroySpawn(CannonClone));
    }

    IEnumerator DestroySpawn(GameObject CannonClone)
    {
        yield return new WaitForSeconds(Random.Range(MinWait, MaxWait));
        GameObject SmokeClone = Instantiate(SmokeEffect, CannonClone.transform.position, CannonClone.transform.rotation);

        Player.GetComponent<ManageAfterEffects>().DestroyEffect(SmokeClone);
        Destroy(CannonClone);
        StartCoroutine(Spawn());

    }


}
