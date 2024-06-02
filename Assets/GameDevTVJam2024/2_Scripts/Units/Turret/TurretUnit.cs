using System.Collections;
using Data;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public class TurretUnit : Unit
    {
        public event UnityAction BulletFired = delegate {  };
        
        [SerializeField] private BoxCollider2D bodyCollider;
        [SerializeField] private BulletSpawnerData bulletSpawnerData;
        [SerializeField] private GameObject bulletSpawnPoint;
        private TurretData _turretStatsData => statsData as TurretData;
        private IEnumerator _attackRoutine;

        public override void EnableCharacterBehaviour()
        {
            IsAlive = true;
            bodyCollider.enabled = true;
            display.EnableUnitSprite();
            StartAttackRoutine();
        }

        public override void DisableCharacterBehaviour()
        {
            bodyCollider.enabled = false;
            display.DisableUnitSprite();
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

            while (IsAlive)
            {
                FireBullet();
                yield return new WaitForSeconds(_turretStatsData.FireRate);
            }
        }

        private void FireBullet()
        {
            var unitObject = gameObject;
            Bullet currentBullet = bulletSpawnerData.Pool.Get();
            currentBullet.MaxContainerRange = _turretStatsData.BulletRange;
            currentBullet.gameObject.transform.position = bulletSpawnPoint.transform.position;
            currentBullet.CurrentDamage = _turretStatsData.BulletDamage;
            currentBullet.SetVelocity(unitObject.transform.up, _turretStatsData.BulletSpeed);
            BulletFired?.Invoke();
        }
    }
}