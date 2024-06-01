using UnityEngine;

namespace Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D enemyRigidbody2D;
        
        public void SetVelocity(float speed)
        {
            enemyRigidbody2D.velocity = -transform.right * speed;
        }

        public void StopRigidbodyMovement()
        {
            enemyRigidbody2D.velocity = Vector2.zero;
        }
    }
}