using Data;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyStatsData", menuName = "Enemy/Stats", order = 0)]
    public class EnemyStatsData : CharacterStatsData
    {
        public int Damage => damage;
        public float MovementSpeed => movementSpeed;
        public float AttackRate => attackRate;
        public int MoneyDropped => moneyDropped;

        [SerializeField] private int damage;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float attackRate;
        [SerializeField] private int moneyDropped;
    }
}