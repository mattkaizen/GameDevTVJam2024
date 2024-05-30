using System.Collections;
using Data;
using UnityEngine;

namespace Enemies
{
    public class TurretUnit : Unit
    {
        [SerializeField] private BoxCollider2D bodyCollider;
        [SerializeField] private BulletSpawner bulletSpawner;
        private TurretData _turretStatsData => statsData as TurretData;
        private IEnumerator _attackRoutine;
        public override void EnableUnitBehaviour()
        {
            StartAttackRoutine();
        }

        public override void DisableUnitBehaviour()
        {
            bodyCollider.enabled = false;
            StopAttackRoutine();
        }

        private void StartAttackRoutine()
        {
            _attackRoutine = AttackRoutine();

            StartCoroutine(_attackRoutine);
        }

        private void StopAttackRoutine()
        {
            if(_attackRoutine == null) return;
            
            StopCoroutine(_attackRoutine);
        }
        private IEnumerator AttackRoutine()
        {
            if (_turretStatsData == null) yield break;
            
            bulletSpawner.Pool.Get();
            yield return new WaitForSeconds(_turretStatsData.FireRate);
        }
    }
}