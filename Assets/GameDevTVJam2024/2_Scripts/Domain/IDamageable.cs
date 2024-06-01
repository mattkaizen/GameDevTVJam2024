namespace Domain
{
    public interface IDamageable
    {
        public bool IsAlive { get; set; }
        int CurrentHealth { get; set; }
        void TakeDamage(int damage);
        void Die();
    }
}