using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyMayhem.GamePlay
{
    public class MainMenuUnlockCursor : MonoBehaviour
    {
        private void Start()
        {
            Cursor.visible = true;
            var cursorLock = Cursor.lockState == CursorLockMode.None;
        }
    }
}
