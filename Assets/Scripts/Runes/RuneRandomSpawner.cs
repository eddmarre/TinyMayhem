using System;
using System.Collections;
using System.Collections.Generic;
using TinyMayhem.Scriptable;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = System.Random;

namespace TinyMayhem.Rune
{
    public class RuneRandomSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] runeGo;
        [SerializeField] private int numberOfRunesToSpawn = 9;

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

            for (var ctr = 0; ctr < numberOfRunesToSpawn; ++ctr)
            {
                var spawnIndex = _randomSpawner.Next(_runeSpawns.Count);
                var runeIndex = _randomRune.Next(runeGo.Length);

                var parentTransform = _runeSpawns[spawnIndex].transform;
                var rune = Instantiate(runeGo[runeIndex], parentTransform.position, parentTransform.rotation);

                rune.transform.SetParent(parentTransform);
                _runeSpawns.Remove(_runeSpawns[spawnIndex]);
            }

            foreach (var vRuneSpawn in _runeSpawns)
            {
                vRuneSpawn.gameObject.SetActive(false);
            }
        }

        public void RespawnRunes()
        {
            var spawners = GetComponentsInChildren<RuneSpawn>();
            foreach (var runeSpawn in spawners)
            {
                _runeSpawns.Add(runeSpawn);
            }

            for (var ctr = 0; ctr < numberOfRunesToSpawn; ++ctr)
            {
                var spawnIndex = _randomSpawner.Next(_runeSpawns.Count);
                var runeIndex = _randomRune.Next(runeGo.Length);

                var parentTransform = _runeSpawns[spawnIndex].transform;
                var rune = Instantiate(runeGo[runeIndex], parentTransform.position, parentTransform.rotation);

                rune.transform.SetParent(parentTransform);
                _runeSpawns.Remove(_runeSpawns[spawnIndex]);
            }

            foreach (var vRuneSpawn in _runeSpawns)
            {
                vRuneSpawn.gameObject.SetActive(false);
            }
        }
    }
}