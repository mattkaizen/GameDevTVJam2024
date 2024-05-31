using UnityEngine;
using UnityEngine.Pool;

namespace Enemies
{
    [CreateAssetMenu(fileName = "BulletSpawnerData", menuName = "BulletSpawner")]
    public class BulletSpawnerData : ScriptableObject
    {
        private IObjectPool<Bullet> _objectPool;
        public IObjectPool<Bullet> Pool
        {
            get => _objectPool;
            set => _objectPool = value;
        }
    }
}