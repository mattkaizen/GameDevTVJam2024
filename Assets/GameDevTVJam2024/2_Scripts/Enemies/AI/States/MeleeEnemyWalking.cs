using Enemies.States;
using UnityEngine;

namespace Enemies
{
    public class MeleeEnemyWalking : EnemyState
    {
        public MeleeEnemyWalking(MeleeEnemyAI ai) : base(ai)
        {
            StateName = "MeleeEnemyWalking";
        }

        protected override void Enter()
        {
            Debug.Log($"Enter {StateName} {AI.IsAlive}");

            AI.Movement.SetVelocity(AI.Data.MovementSpeed);
            base.Enter();
        }

        protected override void Update()
        {
            TryToChangeToDiedState();
            TryToChangeAttackState();
        }

        protected override void Exit()
        {
            Debug.Log($"Exit {StateName}");
            AI.Movement.StopRigidbodyMovement();
        }

        private void TryToChangeAttackState()
        {
            if (AI.DetectionSystem.HasDetectedDamageable(out var damageable))
            {
                Debug.Log("Change to Attack state");
                NextEnemyState = new MeleeEnemyAttacking(AI as MeleeEnemyAI, damageable);
                Stage = Status.Exit;
            }
        }

        private void TryToChangeToDiedState()
        {
            if (AI.IsAlive) return;
            
            NextEnemyState = new MeleeEnemyDied(AI as MeleeEnemyAI);
            Stage = Status.Exit;
        }
    }
}