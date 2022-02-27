using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace TinyMayhem.Scriptable
{
    [CreateAssetMenu(fileName = "Objective", menuName = "PlayerObjective")]
    public class Objective : ScriptableObject
    {
        private int _numberOfShrinesActivated;
        private int _numberOfShrines;

        private void OnEnable()
        {
            _numberOfShrinesActivated = 0;
        }

        public int AddActivatedShrine()
        {
            return ++_numberOfShrinesActivated;
        }

        public int RemainingShrines()
        {
            return _numberOfShrines - _numberOfShrinesActivated;
        }

        public void GetRuneShrines(RuneStone[] runes)
        {
            _numberOfShrines = runes.Length;
            _numberOfShrinesActivated = 0;
        }
    }
}