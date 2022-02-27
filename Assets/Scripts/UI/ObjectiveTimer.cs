using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyMayhem.UI
{
    public class ObjectiveTimer : MonoBehaviour
    {
        private void OnEnable()
        {
            StartCoroutine(DisableTimer());
        }

        IEnumerator DisableTimer()
        {
            yield return new WaitForSeconds(10f);
            gameObject.SetActive(false);
        }
    }
}
