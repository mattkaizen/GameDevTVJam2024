using Data;
using Enemy;
using UnityEngine;
using UnityEngine.Pool;

namespace Enemies
{
    public abstract class EnemyAI : Character
    {
        public EnemyMovement Movement => enemyMovement;
        public EnemyStatsData Data => statsData as EnemyStatsData;
        public EnemyDetectionSystem DetectionSystem => detectionSystem;
        public EnemyAIEventChannelData EnemyAIDied => enemyAIDied;
        public IObjectPool<EnemyAI> Pool
        {
            get => ObjectPool;
            set => ObjectPool = value;
        }

        [SerializeField] private EnemyMovement enemyMovement;
        [SerializeField] private EnemyDetectionSystem detectionSystem;
        [SerializeField] private EnemyAIEventChannelData enemyAIDied;

        protected EnemyState EnemyState;
        
        protected IObjectPool<EnemyAI> ObjectPool;

        
        private void Update()
        {
            if (EnemyState != null)
                EnemyState = EnemyState.Process();
        }

    }
}