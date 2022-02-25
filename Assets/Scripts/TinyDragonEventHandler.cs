using System;
using System.Collections;
using System.Collections.Generic;
using EmeraldAI;
using UnityEngine;

public class TinyDragonEventHandler : MonoBehaviour
{
    public void DisableDragon()
    {
        Debug.Log(gameObject.name + "has died");
        StartCoroutine(DelayedDestroy());
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(6.5f);
        Debug.Log("destroying object");
        Destroy(this.gameObject);
    }
}