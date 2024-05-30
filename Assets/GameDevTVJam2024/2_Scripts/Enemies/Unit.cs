using Data;
using Domain;
using UnityEngine;

namespace Enemies
{
    public abstract class Unit : MonoBehaviour, IDamageable
    {
        public UnitDisplay Display => display;
        public int CurrentHealth { get; set; }

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
        }
        public void Die()
        {
            DisableUnitBehaviour();
        }
    }
}