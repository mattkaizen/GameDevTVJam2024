using Domain;
using UnityEngine;

namespace Enemies
{
    public class MeleeEnemyAI : EnemyAI
    {
        public MeleeDamagePerformer Performer => meleeDamagePerformer;
        [SerializeField] private MeleeDamagePerformer meleeDamagePerformer;
        [SerializeField] private EnemyDisplay enemyDisplay;
        [SerializeField] private BoxCollider2D bodyCollider2D;

        private IDamageable target;
        public override void OnEnable()
        {
            base.OnEnable();
            EnableCharacterBehaviour();
        }

        public override void EnableCharacterBehaviour()
        {
            IsAlive = true;
            enemyDisplay.EnemySprite.enabled = true;
            bodyCollider2D.enabled = true;
            EnemyState = new MeleeEnemyWalking(this);
        }

        public override void DisableCharacterBehaviour()
        {
            enemyDisplay.EnemySprite.enabled = false;
            bodyCollider2D.enabled = false;
            EnemyAIDied.RaiseEvent(this);
        }
    }
}