using System;
using System.Collections;
using System.Collections.Generic;
using ECM.Components;
using ECM.Controllers;
using TinyMayhem.UI;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace TinyMayhem.GamePlay
{
    public class MissionTime : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshPro;
        [SerializeField] private float timeValue = 90;
        private LoseText _loseText;
        private MouseLook _mouseLook;
        private CharacterMovement _characterMovement;
        private GroundDetection _groundDetection;
        private BaseFirstPersonController _playerController;

        private void Awake()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
            _loseText = FindObjectOfType<LoseText>();
            _mouseLook = FindObjectOfType<MouseLook>();
            _characterMovement = FindObjectOfType<CharacterMovement>();
            _groundDetection = FindObjectOfType<GroundDetection>();
            _playerController = FindObjectOfType<BaseFirstPersonController>();
        }

        private void Update()
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
            }

            if (timeValue <= 0)
            {
                
                _mouseLook.SetCursorLock(false);
                _loseText.gameObject.SetActive(true);
                var sphereCollider = GetComponent<SphereCollider>();
                Destroy(sphereCollider);
                Destroy(_mouseLook);
                Destroy(_characterMovement);
                Destroy(_groundDetection);
                Destroy(_playerController);
                Time.timeScale = 0;
            }

            DisplayTime(timeValue);
        }

        void DisplayTime(float timeToDisplay)
        {
            if (timeToDisplay < 0)
            {
                timeToDisplay = 0;
            }

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            _textMeshPro.text = $"{minutes:00}:{seconds:00}";
        }
    }
}