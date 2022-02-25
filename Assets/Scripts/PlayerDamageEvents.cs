using System;
using System.Collections;
using System.Collections.Generic;
using PlayerController;
using UnityEngine;

public class PlayerDamageEvents : MonoBehaviour
{
    [SerializeField] private AudioClip playerHitSound;
    [SerializeField] private AudioClip playerDeathSound;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public void PlayerHit()
    {
        Debug.Log("sound played");
        AudioSource.PlayClipAtPoint(playerHitSound, _player.transform.position);
    }

    public void PlayerDeath()
    {
        Debug.Log("you died");
        AudioSource.PlayClipAtPoint(playerDeathSound,_player.transform.position);
    }
}