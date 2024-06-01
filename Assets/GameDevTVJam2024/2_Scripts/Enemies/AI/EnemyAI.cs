using Enemy;
using UnityEngine;

namespace Enemies
{
    public abstract class EnemyAI : Character
    {
        public EnemyMovement Movement => enemyMovement;
        public EnemyStatsData Data => statsData as EnemyStatsData;
        public EnemyDetectionSystem DetectionSystem => detectionSystem;

        [SerializeField] private EnemyMovement enemyMovement;
        [SerializeField] private EnemyDetectionSystem detectionSystem;

        protected EnemyState EnemyState;
        
        private void Update()
        {
            if (EnemyState != null)
                EnemyState = EnemyState.Process();
        }

    }
}