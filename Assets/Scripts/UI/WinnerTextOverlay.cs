using System;
using System.Collections;
using System.Collections.Generic;
using ECM.Components;
using ECM.Controllers;
using TinyMayhem.Scriptable;
using TMPro;
using UnityEngine;

namespace TinyMayhem.UI
{
    public class WinnerTextOverlay : MonoBehaviour
    {
        [SerializeField] private Objective _objective;
        [SerializeField] private GameObject winSound;
        [SerializeField] private GameObject gameMusic;
        [SerializeField] private GameObject birdsChriping;
        private Canvas _canvas;
        private TextMeshProUGUI _textMeshProUGUI;
        private MouseLook _mouseLook;
        private CharacterMovement _characterMovement;
        private GroundDetection _groundDetection;
        private BaseCharacterController _playerController;

        private void Awake()
        {
            _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
            _canvas = GetComponentInChildren<Canvas>();

            _mouseLook = FindObjectOfType<MouseLook>();
            _characterMovement = FindObjectOfType<CharacterMovement>();
            _groundDetection = FindObjectOfType<GroundDetection>();
            _playerController = FindObjectOfType<BaseCharacterController>();
            winSound.SetActive(false);
        }

        private void Start()
        {
            _textMeshProUGUI.gameObject.SetActive(false);
            _canvas.gameObject.SetActive(false);
            
        }

        private void Update()
        {
            var remainingShrines = _objective.RemainingShrines();
            if (remainingShrines == 0)
            {
                _textMeshProUGUI.gameObject.SetActive(true);
                _canvas.gameObject.SetActive(true);
                winSound.SetActive(true);
                birdsChriping.SetActive(false);
                gameMusic.SetActive(false);
                
                _mouseLook.SetCursorLock(false);
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
}