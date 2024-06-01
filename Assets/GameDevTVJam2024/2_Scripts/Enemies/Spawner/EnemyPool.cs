using UnityEngine;
using UnityEngine.Pool;

namespace Enemies
{
    public class EnemyPool : MonoBehaviour
    {
        public IObjectPool<EnemyAI> Pool
        {
            get => _objectPool;
            set => _objectPool = value;
        }
        
        public EnemyAI EnemyAIPrefab => enemyAIPrefab;

        [SerializeField] private EnemyAI enemyAIPrefab;
        [SerializeField] private int defaultCapacity = 20;
        [SerializeField] private int maxSize = 100;
        
        private IObjectPool<EnemyAI> _objectPool;


        private void Awake()
        {
            _objectPool = new ObjectPool<EnemyAI>(CreateEnemy, OnGetEnemy, OnReleasePool, OnDestroyEnemy, true,
                defaultCapacity, maxSize);
        }

        private EnemyAI CreateEnemy()
        {
            EnemyAI enemyAI = Instantiate(enemyAIPrefab, transform);
            enemyAI.Pool = _objectPool;
            return enemyAI;
        }

        private void OnReleasePool(EnemyAI enemy)
        {
            enemy.gameObject.SetActive(false);
        }

        private void OnGetEnemy(EnemyAI enemy)
        {
            enemy.gameObject.SetActive(true);
        }

        private void OnDestroyEnemy(EnemyAI bullet)
        {
        }
    }
}