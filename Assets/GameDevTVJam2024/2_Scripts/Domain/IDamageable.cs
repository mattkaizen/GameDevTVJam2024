namespace Domain
{
    public interface IDamageable
    {
        int CurrentHealth { get; set; }
        void TakeDamage(int damage);
        void Die();
    }
}