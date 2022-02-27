using System;
using System.Collections;
using ECM.Components;
using ECM.Controllers;
using UnityEngine;
using UnityEngine.PlayerLoop;
using EmeraldAI;
using EmeraldAI.Example;
using TinyMayhem.GamePlay;

namespace TinyMayhem.Player
{
    public class Player : MonoBehaviour
    {
        public event Action OnButtonPressed;
        private EmeraldAIPlayerHealth _playerHealth;
        private PauseHandler _pauseHandler;

        private void Awake()
        {
            _playerHealth = GetComponent<EmeraldAIPlayerHealth>();
            _pauseHandler = FindObjectOfType<PauseHandler>();
        }

        private void Start()
        {
            _pauseHandler.DisableOnStart();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                OnButtonPressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pauseHandler.PauseButtonPressed();
                if (_pauseHandler.isPaused)
                {
                    _pauseHandler.PauseGame();
                    // FindObjectOfType<CharacterMovement>().Pause(true, true);
                }
                else
                {
                    _pauseHandler.UnPauseGame();
                    // FindObjectOfType<MouseLook>().SetCursorLock(true);
                    
                }
            }
        }

        IEnumerator DisableOrEnableCameraMovementDelay(bool value)
        {
            FindObjectOfType<BaseCharacterController>().enabled = true;
            yield return new WaitForSeconds(1f);
        }
    }
}