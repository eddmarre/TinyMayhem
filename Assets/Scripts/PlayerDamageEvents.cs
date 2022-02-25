using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using ECM.Components;
using ECM.Controllers;
using PlayerController;
using UnityEngine;

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
        // var cursor = Cursor.lockState == CursorLockMode.Confined;
        // Cursor.visible = true;
        AudioSource.PlayClipAtPoint(playerDeathSound, _player.transform.position);
        _loseText.gameObject.SetActive(true);
        Destroy(_playerController);
        var sphereCollider = GetComponent<SphereCollider>();
        Destroy(sphereCollider);
        Time.timeScale = 0;
        Destroy(_mouseLook);
        Destroy(_characterMovement);
        Destroy(_groundDetection);
    }
}