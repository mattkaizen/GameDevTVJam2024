using Data;
using Enemies;
using UnityEngine;
using UnityEngine.Pool;

namespace Object
{
    public class PickableMoneySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyAIEventChannelData enemyAIDied;
        [SerializeField] private PickableMoney pickableMoneyPrefab;
        // [SerializeField] private PickableMoneyPoolData spawner;
        [SerializeField] private int defaultCapacity = 20;
        [SerializeField] private int maxSize = 100;

        private IObjectPool<PickableMoney> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<PickableMoney>(CreatePickableMoney, OnGetPickableMoney, OnReleasePool, OnDestroyBullet, true,
                defaultCapacity, maxSize);
        }

        private void OnEnable()
        {
            enemyAIDied.EventRaised += OnEnemyDied;
        }

        private void OnDisable()
        {
            enemyAIDied.EventRaised -= OnEnemyDied;
        }

        private void OnEnemyDied(EnemyAI enemy)
        {
            SpawnPickableMoneyOnEnemyPosition(enemy);
        }

        private void SpawnPickableMoneyOnEnemyPosition(EnemyAI enemy)
        {
            PickableMoney pickableMoney = _pool.Get();
            pickableMoney.MoneyAmount = enemy.Data.MoneyDropped;
            pickableMoney.gameObject.transform.position = enemy.transform.position;
            pickableMoney.gameObject.SetActive(true);
        }

        private PickableMoney CreatePickableMoney()
        {
            PickableMoney pickableMoney = Instantiate(pickableMoneyPrefab, transform);
            pickableMoney.Pool = _pool;

            return pickableMoney;
        }

        private void OnReleasePool(PickableMoney pickableMoney)
        {
            pickableMoney.gameObject.SetActive(false);
        }

        private void OnGetPickableMoney(PickableMoney pickableMoney)
        {
        }

        private void OnDestroyBullet(PickableMoney pickableMoney)
        {
        }
    }
}