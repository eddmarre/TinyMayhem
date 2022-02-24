using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinnerTextOverlay : MonoBehaviour
{
    [SerializeField] private Objective _objective;
    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        _textMeshProUGUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        var remainingShrines = _objective.RemainingShrines();
        if (remainingShrines == 0)
            _textMeshProUGUI.gameObject.SetActive(true);
    }
}