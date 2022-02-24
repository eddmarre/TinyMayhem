using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = System.Random;

public class RuneRandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] runeGo;

    private readonly List<RuneSpawn> _runeSpawns = new List<RuneSpawn>();
    private readonly Random _randomSpawner = new Random();
    private readonly Random _randomRune = new Random();

    private void Awake()
    {
        var spawners = GetComponentsInChildren<RuneSpawn>();
        foreach (var runeSpawn in spawners)
        {
            _runeSpawns.Add(runeSpawn);
        }

        for (var ctr = 0; ctr < 10; ++ctr)
        {
            var spawnIndex = _randomSpawner.Next(_runeSpawns.Count);
            var runeIndex = _randomRune.Next(runeGo.Length);

            var parentTransform = _runeSpawns[spawnIndex].transform;
            var rune = Instantiate(runeGo[runeIndex], parentTransform.position, quaternion.identity);

            rune.transform.SetParent(parentTransform);
            _runeSpawns.Remove(_runeSpawns[spawnIndex]);
        }

        foreach (var vRuneSpawn in _runeSpawns)
        {
            vRuneSpawn.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        // for (var ctr = 0; ctr < 10; ++ctr)
        // {
        //     var spawnIndex = _randomSpawner.Next(_runeSpawns.Count);
        //     var runeIndex = _randomRune.Next(runeGo.Length);
        //
        //     var parentTransform = _runeSpawns[spawnIndex].transform;
        //     var rune = Instantiate(runeGo[runeIndex], parentTransform.position, quaternion.identity);
        //
        //     rune.transform.SetParent(parentTransform);
        //     _runeSpawns.Remove(_runeSpawns[spawnIndex]);
        // }
        //
        // foreach (var vRuneSpawn in _runeSpawns)
        // {
        //     vRuneSpawn.gameObject.SetActive(false);
        // }
    }
}