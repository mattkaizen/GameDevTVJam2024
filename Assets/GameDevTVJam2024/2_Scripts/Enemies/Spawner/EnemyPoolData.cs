using UnityEngine;
using UnityEngine.Pool;

namespace Enemies
{
    [CreateAssetMenu(fileName = "EnemyPoolData", menuName = "Enemy/Pool", order = 0)]
    public class EnemyPoolData : ScriptableObject
    {
        private IObjectPool<EnemyAI> _objectPool;
        public IObjectPool<EnemyAI> Pool
        {
            get => _objectPool;
            set => _objectPool = value;
        }
    }
}