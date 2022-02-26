using System;
using System.Collections;
using System.Collections.Generic;
using PlayerController;
using TMPro;
using UnityEngine;

public class PetPlayerDetection : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI petText;
    
    public void PlayerDetected()
    {
        petText.gameObject.SetActive(true);
        StartCoroutine(DisableTextDelay());
    }

    private IEnumerator DisableTextDelay()
    {
        yield return new WaitForSeconds(5f);
        petText.gameObject.SetActive(false);
    }
}
