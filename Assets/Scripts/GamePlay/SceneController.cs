using System;
using System.Collections;
using System.Collections.Generic;
using ECM.Components;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TinyMayhem.GamePlay
{
    public class SceneController : MonoBehaviour
    {
        public void LoadMainMenu()
        {
            try
            {
                FindObjectOfType<MouseLook>().SetCursorLock(false);
            }
            catch
            {
                //do nothing
            }

            Time.timeScale = 1f;
            const int mainMenuIndex = 0;
            SceneManager.LoadScene(mainMenuIndex);
        }

        public void LoadGame()
        {
            Time.timeScale = 1f;
            const int gameIndex = 1;
            SceneManager.LoadScene(gameIndex);
        }

        public void LoadGameAfterCuteScene()
        {
            StartCoroutine(CutsceneDelayTimer());
        }


        IEnumerator CutsceneDelayTimer()
        {
            yield return new WaitForSeconds(8f);
            Time.timeScale = 1f;
            const int gameIndex = 1;
            SceneManager.LoadScene(gameIndex);
        }
    }
}