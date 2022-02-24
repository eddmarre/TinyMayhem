using System;
using UnityEngine;

namespace TestableScripts
{
    public class Player : MonoBehaviour
    {
        static int _health = 100;
        public static int health => _health;

        public event Action OnButtonPressed;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                OnButtonPressed?.Invoke();
            }
        }
    }
}