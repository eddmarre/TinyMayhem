using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VolumeMixer", menuName = "VolumeController")]
public class VolumeMixer : ScriptableObject
{
    [Range(0, 1)] private float _volume = 1f;

    public void SetCurrentVolume(float newVolume)
    {
        _volume = newVolume;
    }

    public float GetCurrentVolume()
    {
        return _volume;
    }
}