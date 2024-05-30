using UnityEngine;
using UnityEngine.Pool;

namespace Enemies
{
    public class Bullet : MonoBehaviour
    {
        private IObjectPool<Bullet> _objectPool;

        public IObjectPool<Bullet> Pool
        {
            get => _objectPool;
            set => _objectPool = value;
        }
    }
}