using UnityEngine;

namespace Enemies
{
    public class EnemyDisplay : MonoBehaviour
    {
        public SpriteRenderer EnemySprite
        {
            get => enemySprite;
            set => enemySprite = value;
        }
        
        [SerializeField] private SpriteRenderer enemySprite;
    }
}