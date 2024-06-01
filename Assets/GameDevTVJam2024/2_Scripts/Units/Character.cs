using Data;
using Domain;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public abstract class Character : MonoBehaviour, IDamageable
    {
        public UnityEvent Died;
        public bool IsAlive { get; set; }
        public int CurrentHealth { get; set; }

        [SerializeField] protected CharacterStatsData statsData;
        [SerializeField] protected Health health;

        public virtual void OnEnable()
        {
            InitializeHealth();
        }
        
        public abstract void EnableCharacterBehaviour();
        public abstract void DisableCharacterBehaviour();
        
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
            DisableCharacterBehaviour();
            Died?.Invoke();
            Debug.Log($"Character: {gameObject.name} died");
        }

    }
}