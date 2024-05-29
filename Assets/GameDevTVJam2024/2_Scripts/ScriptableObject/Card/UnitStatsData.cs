using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Card/Unit", order = 0)]
    public class UnitStatsData : ScriptableObject
    {
        public int MaxHealth => maxHealth;

        [SerializeField] private int maxHealth;
    }
}