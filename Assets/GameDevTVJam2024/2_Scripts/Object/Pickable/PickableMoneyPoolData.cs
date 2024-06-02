using UnityEngine;
using UnityEngine.Pool;

namespace Object
{
    [CreateAssetMenu(fileName = "PickableMoneyPoolData", menuName = "Pool/PickableMoney", order = 0)]
    public class PickableMoneyPoolData : ScriptableObject
    {
        private IObjectPool<PickableMoney> _objectPool;
        public IObjectPool<PickableMoney> Pool
        {
            get => _objectPool;
            set => _objectPool = value;
        }
    }
}