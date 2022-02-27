using System;
using System.Collections;
using System.Collections.Generic;
using TinyMayhem.Scriptable;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace TinyMayhem.GamePlay
{
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
}