using Data;
using Domain;
using UnityEngine;
using UnityEngine.Pool;

namespace Object
{
    public class PickableMoney : MonoBehaviour, IPickable
    {
        public IObjectPool<PickableMoney> Pool
        {
            get => _pool;
            set => _pool = value;
        }
        
        [SerializeField] private IntEventChannelData moneyPicked;

        private IObjectPool<PickableMoney> _pool;

        public int MoneyAmount
        {
            get => _moneyAmount;
            set => _moneyAmount = value;
        }


        private int _moneyAmount;

        public void Pickup()
        {
            moneyPicked.RaiseEvent(_moneyAmount);
            _pool.Release(this);
        }
    }
}