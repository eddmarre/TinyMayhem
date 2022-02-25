using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MissionTime : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    [SerializeField] private float timeValue = 90;
    private LoseText _loseText;


    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _loseText = FindObjectOfType<LoseText>();
    }

    private void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        if (timeValue <= 0)
        {
            Debug.Log("timer up");
            _loseText.gameObject.SetActive(true);
        }
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _textMeshPro.text = $"{minutes:00}:{seconds:00}";
    }
}