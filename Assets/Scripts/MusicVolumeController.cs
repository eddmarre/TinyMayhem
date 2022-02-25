using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MusicVolumeController : MonoBehaviour
{
    [SerializeField] private VolumeMixer volumeMixer;
    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _audioSource.volume = volumeMixer.GetCurrentVolume();
    }
}