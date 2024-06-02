using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enemies.Cycle;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemySpawnerSystem : MonoBehaviour
    {
        [Header("Spawner Settings")]
        [SerializeField] private float spawnRate;
        [SerializeField] private float timeToUpdateCycle;
        [SerializeField] private List<GameObject> spawnPoints;
        [Header("Enemy x Cycle")]
        [SerializeField] private List<EnemyCycle> enemyCycles;
        [Header("Dependencies")]
        [SerializeField] private List<EnemyPool> enemyPools;
        [SerializeField] private List<EnemyAI> enemiesToSpawn;
        [SerializeField] private List<EnemyAI> currentSpawnEnemies;
        
        private IEnumerator _spawnEnemiesOnCycleRoutine;
        private IEnumerator _updateCycleRoutine;

        private bool _isSpawningEnemiesOnCycle;
        private int _currentEnemyCycleIndex;

        private void OnEnable()
        {
            StartSpawnOnCycles();
        }

        private void StartSpawnOnCycles()
        {
            _isSpawningEnemiesOnCycle = true;
            _spawnEnemiesOnCycleRoutine = SpawnEnemiesOnCycleRoutine();
            _updateCycleRoutine = UpdateCycleRoutine();

            AddEnemiesToSpawn();
            StartCoroutine(_updateCycleRoutine);
            StartCoroutine(_spawnEnemiesOnCycleRoutine);
        }
        private void SpawnEnemies()
        {
            foreach (var enemyToSpawn in enemiesToSpawn)
            {
                EnemyAI enemyAI = GetEnemyAIFromPool(enemyToSpawn);
                GameObject spawnPoint = GetRandomSpawnPoint();
                
                if(spawnPoint == null) continue;
                if(enemyAI == null) continue;

                var enemyObject = enemyAI.gameObject;
                enemyObject.transform.position = spawnPoint.transform.position;
                enemyObject.transform.rotation = spawnPoint.transform.rotation;
                
                enemyAI.EnableCharacterBehaviour();
                currentSpawnEnemies.Add(enemyAI);
            }
        }

        private EnemyAI GetEnemyAIFromPool(EnemyAI enemyAI)
        {
            EnemyPool matchPool = enemyPools.FirstOrDefault(pool => enemyAI == pool.EnemyAIPrefab);

            return matchPool == null ? null : matchPool.Pool.Get();
        }

        private void AddEnemiesToSpawn()
        {
            foreach (var enemyAI in enemyCycles[_currentEnemyCycleIndex].EnemiesToAdd)
            {
                enemiesToSpawn.Add(enemyAI);
            }
        }

        private void UpdateEnemyCycleIndex()
        {
            int cycleIndex = _currentEnemyCycleIndex++;

            if (_currentEnemyCycleIndex == enemyCycles.Count - 1)
            {
                _currentEnemyCycleIndex = 0;
            }
            else
            {
                _currentEnemyCycleIndex = cycleIndex;
            }
        }

        private IEnumerator SpawnEnemiesOnCycleRoutine()
        {
            while (_isSpawningEnemiesOnCycle)
            {
                SpawnEnemies();
                yield return new WaitForSeconds(spawnRate);
            }
        }

        private IEnumerator UpdateCycleRoutine()
        {
            while (_isSpawningEnemiesOnCycle)
            {
                yield return new WaitForSeconds(timeToUpdateCycle);
                UpdateEnemyCycleIndex();
                AddEnemiesToSpawn();
            }
        }

        private GameObject GetRandomSpawnPoint()
        {
            if (spawnPoints.Count == 0) return null;
            
            int randomIndex = Random.Range(0, spawnPoints.Count);

            return spawnPoints[randomIndex];
        }
    }
}