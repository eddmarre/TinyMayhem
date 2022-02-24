using System;
using UnityEngine;
using UnityEngine.PlayerLoop;


[CreateAssetMenu(fileName = "Objective", menuName = "PlayerObjective")]
public class Objective : ScriptableObject
{
    private int _numberOfShrinesActivated;
    private int _numberOfShrines;

    private void OnEnable()
    {
        _numberOfShrinesActivated = 0;
        // var shrines = FindObjectsOfType<RuneStoneTrigger>();
        // _numberOfShrines = shrines.Length;
    }
    

    public int AddActivatedShrine()
    {
        return ++_numberOfShrinesActivated;
    }

    public int RemainingShrines()
    {
        return _numberOfShrines - _numberOfShrinesActivated;
    }

    public void GetRuneShrines(RuneStoneTrigger[] runeStoneTriggers)
    {
        _numberOfShrines = runeStoneTriggers.Length;
    }
}