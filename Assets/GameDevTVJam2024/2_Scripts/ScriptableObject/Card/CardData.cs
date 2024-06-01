using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CardData", menuName = "Card", order = 0)]
    public class CardData : ScriptableObject
    {
        //Maybe CD
        public int Cost => cost;
        public CharacterStatsData CharacterStatsData => characterStatsData;
        public GameObject UnitPrefab => unitPrefab;

        [SerializeField] private int cost;
        [SerializeField] private GameObject unitPrefab;
        [SerializeField] private CharacterStatsData characterStatsData;
    }
}