using System;
using System.Collections;
using System.Collections.Generic;
using EmeraldAI;
using EmeraldAI.Example;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace TinyMayhem.UI
{

    public class HealthText : MonoBehaviour
    {
        private EmeraldAIPlayerHealth _playerHealth;
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            _playerHealth = FindObjectOfType<EmeraldAIPlayerHealth>();
        }

        private void Update()
        {
            _text.text = _playerHealth.CurrentHealth.ToString();
            if (_playerHealth.CurrentHealth <= 0)
            {
                Destroy(_text);
            }
        }
    }
}