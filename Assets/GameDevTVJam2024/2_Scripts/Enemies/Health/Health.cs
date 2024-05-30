using System;
using UnityEngine;

namespace Enemies
{
    public class Health : MonoBehaviour
    {
        public event Action HealthChanged;
        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }
        public int MinHealth
        {
            get => _minHealth;
            set => _minHealth = value;
        }
        public int MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        private int _minHealth;
        private int _maxHealth;
        
        private int _currentHealth;
        

        public void Increment(int amount)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
            UpdateHealth();
        }

        public void Decrement(int amount)
        {
            _currentHealth -= amount;
            _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
            UpdateHealth();
        }
        private void UpdateHealth()
        {
            HealthChanged?.Invoke();
        }
    }
}