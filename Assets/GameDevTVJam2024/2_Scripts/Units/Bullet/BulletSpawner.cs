using UnityEngine;
using UnityEngine.Pool;

namespace Enemies
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private BulletSpawnerData spawner;
        [SerializeField] private int defaultCapacity = 20;
        [SerializeField] private int maxSize = 100;
        
        private IObjectPool<Bullet> _objectPool;

        private void Awake()
        {
            spawner.Pool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleasePool, OnDestroyBullet, true,
                defaultCapacity, maxSize);
        }

        private Bullet CreateBullet()
        {
            Bullet bullet = Instantiate(bulletPrefab, transform);
            bullet.Pool = spawner.Pool;

            return bullet;
        }

        private void OnReleasePool(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        private void OnGetBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
        }

        private void OnDestroyBullet(Bullet bullet)
        {
        }
    }
}