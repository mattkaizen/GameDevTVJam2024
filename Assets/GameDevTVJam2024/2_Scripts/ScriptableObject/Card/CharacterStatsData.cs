using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Unit/unit", order = 0)]
    public class CharacterStatsData : ScriptableObject
    {
        public int MaxHealth => maxHealth;

        [SerializeField] private int maxHealth;
    }
}