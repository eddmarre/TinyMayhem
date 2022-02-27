using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyMayhem.GamePlay
{
    public class TimeScaleReset : MonoBehaviour
    {
        void Start()
        {
            Time.timeScale = 1f;
        }
    }
}