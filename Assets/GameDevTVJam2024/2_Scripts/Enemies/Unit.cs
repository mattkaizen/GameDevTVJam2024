using Data;
using Domain;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public abstract class Unit : MonoBehaviour, IDamageable
    {
        public UnityEvent Died;
        public UnitDisplay Display => display;
        public int CurrentHealth { get; set; }
        public bool IsAlive { get; set; }

        [SerializeField] protected UnitStatsData statsData;
        [SerializeField] protected UnitDisplay display;
        [SerializeField] protected Health health;

        private void OnEnable()
        {
            InitializeHealth();
        }
        
        public abstract void EnableUnitBehaviour();
        public abstract void DisableUnitBehaviour();
        
        private void InitializeHealth()
        {
            health.MinHealth = 0;
            health.MaxHealth = statsData.MaxHealth;
            health.CurrentHealth = health.MaxHealth;
        }
        public void TakeDamage(int damage)
        {
            health.Decrement(damage);
            
            if(!health.HasRemainingHealth())
                Die();
        }
        public void Die()
        {
            IsAlive = false;
            DisableUnitBehaviour();
            Died?.Invoke();
        }


    }
}