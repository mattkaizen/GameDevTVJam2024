using Data;
using Domain;
using Enemies;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCore : MonoBehaviour, IDamageable
{
    public UnityEvent Died;
    
    [SerializeField] private Health health;
    [SerializeField] private CharacterStatsData statsData;
    public bool IsAlive { get; set; }
    
    public int CurrentHealth
    {
        get => health.CurrentHealth;
        set => health.CurrentHealth = value;
    }

    private void OnEnable()
    {
        IsAlive = true;
        InitializeHealth();
    }

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
        Died?.Invoke();
        Debug.Log($"Character: {gameObject.name} died");
    }
}
