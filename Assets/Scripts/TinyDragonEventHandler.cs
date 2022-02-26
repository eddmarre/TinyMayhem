using System;
using System.Collections;
using System.Collections.Generic;
using EmeraldAI;
using UnityEngine;

public class TinyDragonEventHandler : MonoBehaviour
{
    public void DisableDragon()
    {
        StartCoroutine(DelayedDestroy());
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(6.5f);
        Destroy(this.gameObject);
    }
}