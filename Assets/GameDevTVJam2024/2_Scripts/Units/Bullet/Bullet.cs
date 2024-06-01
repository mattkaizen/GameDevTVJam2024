using System.Collections;
using Domain;
using UnityEngine;
using UnityEngine.Pool;

namespace Enemies
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private IObjectPool<Bullet> _objectPool;
        public int CurrentDamage
        {
            get => _currentDamage;
            set => _currentDamage = value;
        }
        public int MaxContainerRange
        {
            get => _maxContainerRange;
            set => _maxContainerRange = value + 1;
        }

        const float minDistanceThresholdToContainer = 0.05f;

        private int _currentDamage;
        private int _maxContainerRange;
        private int _crossedUnitContainerAmount;

        public IObjectPool<Bullet> Pool
        {
            get => _objectPool;
            set => _objectPool = value;
        }

        private void OnEnable()
        {
            InitializeBullet();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            TryDamage(other.gameObject);
            TryUpdateCrossedContainerAmount(other.gameObject);
        }

        private void TryDamage(GameObject other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(CurrentDamage);
                DisableBullet();
            }
        }

        private void TryUpdateCrossedContainerAmount(GameObject other)
        {
            if (other.TryGetComponent<IUnitContainer>(out var container))
            {
                _crossedUnitContainerAmount++;
                if (IsOnTheMaxContainer())
                {
                    DeactivateBulletAtMaxRange(other);
                }
            }
        }

        public void SetVelocity(Vector2 direction, float movementSpeed)
        {
            _rigidbody2D.velocity = direction * movementSpeed;
        }

        private IEnumerator DeactivateBulletAtMaxRangeRoutine(GameObject container)
        {
            yield return new WaitUntil(() => IsOnTheMaxContainerRange(container));
            DisableBullet();
        }

        private void DeactivateBulletAtMaxRange(GameObject container)
        {
            StartCoroutine(DeactivateBulletAtMaxRangeRoutine(container));
        }

        private void InitializeBullet()
        {
            _crossedUnitContainerAmount = 0;
            _rigidbody2D.velocity = Vector2.zero;
        }

        private void DisableBullet()
        {
            _objectPool.Release(this);
        }

        private bool IsOnTheMaxContainerRange(GameObject maxContainer)
        {
            return IsCloseToMaxContainerCenter(maxContainer) || HasCrossedMaxContainerRange(maxContainer);
        }

        private bool HasCrossedMaxContainerRange(GameObject maxContainer)
        {
            var maxContainerPosition = maxContainer.transform.position;

            Vector3 directionToMaxContainer = gameObject.transform.position - maxContainerPosition;
            Vector3 crossProduct = Vector3.Cross(maxContainer.transform.right, directionToMaxContainer);

            return crossProduct.z > 0;
        }

        private bool IsCloseToMaxContainerCenter(GameObject maxContainer)
        {
            float distanceToMaxContainer = Vector3.Distance(_rigidbody2D.position, maxContainer.transform.position);
            return distanceToMaxContainer < minDistanceThresholdToContainer;
        }

        private bool IsOnTheMaxContainer()
        {
            return _crossedUnitContainerAmount == MaxContainerRange;
        }
    }
}