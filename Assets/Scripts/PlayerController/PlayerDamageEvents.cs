using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using ECM.Components;
using ECM.Controllers;
using TinyMayhem.UI;
using UnityEngine;

namespace TinyMayhem.Player
{
    public class PlayerDamageEvents : MonoBehaviour
    {
        [SerializeField] private AudioClip playerHitSound;
        [SerializeField] private AudioClip playerDeathSound;
        private BaseFirstPersonController _playerController;
        private GroundDetection _groundDetection;
        private MouseLook _mouseLook;
        private CharacterMovement _characterMovement;
        private LoseText _loseText;
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _loseText = FindObjectOfType<LoseText>();
            _playerController = FindObjectOfType<BaseFirstPersonController>();
            _mouseLook = FindObjectOfType<MouseLook>();
            _characterMovement = FindObjectOfType<CharacterMovement>();
            _groundDetection = FindObjectOfType<GroundDetection>();
        }

        private void Start()
        {
            _loseText.gameObject.SetActive(false);
        }

        public void PlayerHit()
        {
            AudioSource.PlayClipAtPoint(playerHitSound, _player.transform.position);
        }

        public void PlayerDeath()
        {
            _mouseLook.SetCursorLock(false);
            AudioSource.PlayClipAtPoint(playerDeathSound, _player.transform.position);
            _loseText.gameObject.SetActive(true);
            var sphereCollider = GetComponent<SphereCollider>();
            Destroy(sphereCollider);
            Destroy(_mouseLook);
            Destroy(_characterMovement);
            Destroy(_groundDetection);
            Destroy(_playerController);
            Time.timeScale = 0;
        }
    }
}