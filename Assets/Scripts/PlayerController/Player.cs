using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using EmeraldAI;
using EmeraldAI.Example;

namespace PlayerController
{
    public class Player : MonoBehaviour
    {
        public event Action OnButtonPressed;
        private EmeraldAIPlayerHealth _playerHealth;

        private void Awake()
        {
            _playerHealth = GetComponent<EmeraldAIPlayerHealth>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                OnButtonPressed?.Invoke();
            }

            Debug.Log(_playerHealth.CurrentHealth);
        }
    }
}