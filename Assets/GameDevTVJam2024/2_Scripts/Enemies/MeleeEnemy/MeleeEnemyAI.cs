using Domain;
using UnityEngine;

namespace Enemies
{
    public class MeleeEnemyAI : EnemyAI
    {
        public MeleeDamagePerformer Performer => meleeDamagePerformer;
        [SerializeField] private MeleeDamagePerformer meleeDamagePerformer;
        [SerializeField] private BoxCollider2D bodyCollider2D;

        private IDamageable target;
        public override void OnEnable()
        {
            base.OnEnable();
            Debug.Log("Melee enemy enabled");
            EnableCharacterBehaviour();
        }

        public override void EnableCharacterBehaviour()
        {
            IsAlive = true;
            bodyCollider2D.enabled = true;
            EnemyState = new MeleeEnemyWalking(this);
        }

        public override void DisableCharacterBehaviour()
        {
            bodyCollider2D.enabled = false;
        }
    }
}