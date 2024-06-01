using Domain;
using UnityEngine;

namespace Enemies.States
{
    public class MeleeEnemyAttacking : EnemyState
    {
        public MeleeEnemyAttacking(MeleeEnemyAI ai, IDamageable damageable) : base(ai)
        {
            _damageableTarget = damageable;
            _meleeEnemyAI = ai;
            StateName = "Melee Enemy Attacking";
        }

        private IDamageable _damageableTarget;
        private MeleeEnemyAI _meleeEnemyAI;

        protected override void Enter()
        {
            Debug.Log($"Enter {StateName}");
            _meleeEnemyAI.Performer.StartMeleeAttack(_damageableTarget);
            base.Enter();
        }

        protected override void Update()
        {
            TryToChangeToDiedState();
            TryToChangeToWalkingState();
        }
        
        protected override void Exit()
        {
            Debug.Log($"Exit {StateName}");

            _meleeEnemyAI.Performer.StopMeleeAttack();
            base.Exit();
        }

        private void TryToChangeToWalkingState()
        {
            if (_damageableTarget.IsAlive) return;
            
            NextEnemyState = new MeleeEnemyWalking(AI as MeleeEnemyAI);
            Stage = Status.Exit;
        }


        
        private void TryToChangeToDiedState()
        {
            if (AI.IsAlive) return;
            
            NextEnemyState = new MeleeEnemyDied(AI as MeleeEnemyAI);
            Stage = Status.Exit;
        }
    }
}