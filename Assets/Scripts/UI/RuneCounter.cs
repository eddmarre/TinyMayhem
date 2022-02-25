using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RuneCounter : MonoBehaviour
{
    [SerializeField] private Objective _objective;
    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _objective.GetRuneShrines(FindObjectsOfType<RuneStone>());
    }

    private void FixedUpdate()
    {
        _textMeshPro.text = _objective.RemainingShrines().ToString();
    }

    public void GetRuneSpawns()
    {
        _objective.GetRuneShrines(FindObjectsOfType<RuneStone>());
    }
}