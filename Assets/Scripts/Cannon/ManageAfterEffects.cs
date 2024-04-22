using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAfterEffects : MonoBehaviour
{
   
    public void DestroyEffect(GameObject obj)
    {
        StartCoroutine(DestroyNow(obj));
    }

    IEnumerator DestroyNow(GameObject obj)
    {
        yield return new WaitForSeconds(3);
        Destroy(obj);
    }


}
