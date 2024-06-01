using System.Collections;
using Domain;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public class MeleeDamagePerformer : MonoBehaviour
    {
        public UnityEvent attacked;

        [SerializeField] private MeleeEnemyAI meleeEnemyAI;

        private IEnumerator _meleeAttackRoutine;

        private IEnumerator MeleeAttackRoutine(IDamageable damageableTarget)
        {
            while (damageableTarget.IsAlive)
            {
                damageableTarget.TakeDamage(meleeEnemyAI.Data.Damage);
                attacked?.Invoke();
                yield return new WaitForSeconds(meleeEnemyAI.Data.AttackRate);
            }
        }

        public void StartMeleeAttack(IDamageable targetDamageable)
        {
            _meleeAttackRoutine = MeleeAttackRoutine(targetDamageable);

            StartCoroutine(_meleeAttackRoutine);
        }

        public void StopMeleeAttack()
        {
            if (_meleeAttackRoutine != null)
                StopCoroutine(_meleeAttackRoutine);
        }
    }
}