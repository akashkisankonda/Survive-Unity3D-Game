using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Collectables : MonoBehaviour
{
    public GameObject HealthEffect;
    public GameObject SpeedEffect;
    public GameObject DamageEffect;
    public GameObject SlowEffect;


    public float Health;
    public float TimeSlowSpeed = .5f;


    float SpeedActiveTime;
    public float Speed;
    public float SpeedEffectTime;
    bool SpeedActive = false;
    float TempSpeedEffectTime;

    float DamageResistanceActiveTime;
    public float DamageResistanceEffectTime = 10;
    float TempDamageResistanceEffectTime;
    bool DamageResistanceActive = false;

    float SlowTimeActiveTime;
    public float SlowTimeEffectTime = 10f;
    float TempSlowTimeEffectTime;
    bool SlowTimeActive = false;


    GameObject SpeedT;
    GameObject SlowT;
    GameObject DamageT;

    public Gradient Speedgrad;

    private void Start()
    {
        SpeedActiveTime = SpeedEffectTime;
        TempSpeedEffectTime = SpeedEffectTime;

        DamageResistanceActiveTime = DamageResistanceEffectTime;
        TempDamageResistanceEffectTime = DamageResistanceEffectTime;

        TempSlowTimeEffectTime = SlowTimeEffectTime;
        SlowTimeActiveTime = SlowTimeEffectTime;


        SpeedT = GameObject.FindWithTag("SpeedT");
        SlowT = GameObject.FindWithTag("SlowT");
        DamageT = GameObject.FindWithTag("DamageT");

    }

    private void Update()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
    private void FixedUpdate()
    {
        if (Time.timeScale == 1 && SlowTimeActive)
        {
            Time.timeScale = TimeSlowSpeed;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HealthSpell")
        {
            Transform SpellPos = collision.gameObject.transform;
            GameObject EffectClone = Instantiate(HealthEffect, SpellPos.position, SpellPos.rotation);
            EffectClone.transform.SetParent(null);
            StartCoroutine(DestroyEffect(EffectClone));
            Destroy(collision.gameObject);
            GiveHealth(Health);
        }
        if(collision.gameObject.tag == "SpeedSpell")
        {
            Transform SpellPos = collision.gameObject.transform;
            GameObject EffectClone = Instantiate(SpeedEffect, SpellPos.position, SpellPos.rotation);

            EffectClone.transform.SetParent(null);
            StartCoroutine(DestroyEffect(EffectClone));
            Destroy(collision.gameObject);
            if(SpeedActive == false)
            {
                GiveSpeed(Speed);
                SpeedT.GetComponent<SpellTimers>().time = 10;
            }
            else
            {
                SpeedActiveTime += TempSpeedEffectTime;
                SpeedT.GetComponent<SpellTimers>().time += 10;
            }
        }
        if (collision.gameObject.tag == "DamageResistenseSpell")
        {
            Transform SpellPos = collision.gameObject.transform;
            GameObject EffectClone = Instantiate(DamageEffect, SpellPos.position, SpellPos.rotation);
            EffectClone.transform.SetParent(null);
            StartCoroutine(DestroyEffect(EffectClone));
            Destroy(collision.gameObject);
            if(DamageResistanceActive == false)
            {
                GiveDamageResistance();
                DamageT.GetComponent<SpellTimers>().time = 10;
            }
            else
            {
                DamageResistanceActiveTime += TempDamageResistanceEffectTime;
                DamageT.GetComponent<SpellTimers>().time += 10;
            }
        }
        if (collision.gameObject.tag == "SlowMotionSpell")
        {
            Transform SpellPos = collision.gameObject.transform;
            GameObject EffectClone = Instantiate(SlowEffect, SpellPos.position, SpellPos.rotation);
            EffectClone.transform.SetParent(null);
            StartCoroutine(DestroyEffect(EffectClone));
            Destroy(collision.gameObject);
            if(SlowTimeActive == false)
            {
                SlowTime();
                SlowT.GetComponent<SpellTimers>().time = 10 / 2;
            }
            else
            {
                SlowTimeActiveTime += SlowTimeEffectTime;
                SlowT.GetComponent<SpellTimers>().time += 10 / 2;
            }  
        }
    }
    void GiveHealth(float health)
    {
        gameObject.GetComponent<Health>().PlayerHealth += health;
        gameObject.GetComponent<Health>().TempPlayerHealth = gameObject.GetComponent<Health>().PlayerHealth;
    }
    void GiveSpeed(float Speed)
    {
        gameObject.GetComponent<NinjaMovements>().RunSpeed += Speed;
        SpeedActive = true;
        /*Debug.Log("Speed Active");*/
        StartCoroutine(RemoveSpeed(Speed));
    }
    void GiveDamageResistance()
    {
        //give resistance
        gameObject.GetComponent<Health>().TempPlayerHealth = gameObject.GetComponent<Health>().PlayerHealth;
        gameObject.GetComponent<Health>().DamageResistance = true;
        DamageResistanceActive = true;
        StartCoroutine(RemoveDamageResistance());
        /*Debug.Log("Damage Resistance Active");*/
    }
    void SlowTime()
    {
        //Slow the time
        
        SlowTimeActive = true;
        StartCoroutine(RemoveSlowTime());
        Time.timeScale = TimeSlowSpeed;
        /*Debug.Log("Slow Time Active");*/
    }
    IEnumerator RemoveSlowTime()
    {
        yield return new WaitForSeconds(SlowTimeEffectTime / 2);
        while(SlowTimeEffectTime != SlowTimeActiveTime)
        {
            SlowTimeEffectTime += TempSlowTimeEffectTime;
            yield return new WaitForSeconds(TempSlowTimeEffectTime / 2);
        }
        SlowTimeActive = false;
        SlowTimeEffectTime = TempSlowTimeEffectTime;
        SlowTimeActiveTime = TempSlowTimeEffectTime;
        /*Debug.Log("Slow Time Deactivated");*/
        //Remove Slow Time
        Time.timeScale = 1;
    }
    IEnumerator RemoveDamageResistance()
    {
        yield return new WaitForSeconds(DamageResistanceEffectTime);
        while(DamageResistanceEffectTime != DamageResistanceActiveTime)
        {
            DamageResistanceEffectTime += TempDamageResistanceEffectTime;
            yield return new WaitForSeconds(TempDamageResistanceEffectTime);
        }
        DamageResistanceEffectTime = TempDamageResistanceEffectTime;
        DamageResistanceActiveTime = TempDamageResistanceEffectTime;
        gameObject.GetComponent<Health>().DamageResistance = false;
        DamageResistanceActive = false;
        /*Debug.Log("Damage Resistance Deactivated");*/
    }
    IEnumerator RemoveSpeed(float Speed)
    {
        yield return new WaitForSeconds(SpeedEffectTime);
        while(SpeedEffectTime != SpeedActiveTime)
        {
            SpeedEffectTime += TempSpeedEffectTime;
            yield return new WaitForSeconds(TempSpeedEffectTime);
        }
        SpeedEffectTime = TempSpeedEffectTime;
        SpeedActiveTime = TempSpeedEffectTime;
        gameObject.GetComponent<NinjaMovements>().RunSpeed -= Speed;
        SpeedActive = false;
        /*Debug.Log("Speed Deactivated");*/
    }
    IEnumerator DestroyEffect(GameObject Effect)
    {
        yield return new WaitForSeconds(5);
        Destroy(Effect);
    }
}
