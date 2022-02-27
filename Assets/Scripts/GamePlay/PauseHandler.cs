using System;
using System.Collections;
using System.Collections.Generic;
using ECM.Components;
using ECM.Controllers;
using UnityEngine;

namespace TinyMayhem.GamePlay
{
    public class PauseHandler : MonoBehaviour
    {
        public bool isPaused;
        private BaseCharacterController _baseCharacterController;

        private void Awake()
        {
            _baseCharacterController = FindObjectOfType<BaseCharacterController>();
        }

        public void DisableOnStart()
        {
            gameObject.SetActive(false);
            isPaused = false;
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            isPaused = true;
            gameObject.SetActive(true);
            FindObjectOfType<CharacterMovement>().Pause(true, true);
        }

        public void UnPauseGame()
        {
            Time.timeScale = 1;
            isPaused = false;
            FindObjectOfType<CharacterMovement>().Pause(false, true);
            FindObjectOfType<MouseLook>().SetCursorLock(true);
            Cursor.visible = false;
            gameObject.SetActive(false);

        }

        public void PauseButtonPressed()
        {
            isPaused = !isPaused;
        }

        IEnumerator DisableOrEnableCameraMovementDelay(bool value)
        {
            yield return new WaitForSeconds(1f);
            _baseCharacterController.enabled = true;
        }
    }
}