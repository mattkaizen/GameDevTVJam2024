using Domain;
using UnityEngine;

namespace Enemies
{
    public class EnemyDetectionSystem : MonoBehaviour
    {
        [SerializeField] private LayerMask unitLayer;
        [SerializeField] private float rayDistance;
        [SerializeField] private GameObject raycastOrigin;

        private void OnDrawGizmosSelected()
        {
            Debug.DrawRay(raycastOrigin.transform.position, -transform.right * rayDistance, Color.red);
        }

        public GameObject RaycastToObject()
        {
            GameObject container = null;

            RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.transform.position, -transform.right, rayDistance,
                unitLayer);

            if (hit.collider != null)
            {
                Debug.Log($"Enemy Raycast2d Object: {hit.collider.gameObject.name}");
                container = hit.collider.gameObject;
            }

            return container;
        }

        public bool HasDetectedDamageable(out IDamageable detectedDamageable)
        {
            detectedDamageable = null;
            GameObject damageableObject = RaycastToObject();

            if (damageableObject != null && damageableObject.TryGetComponent<IDamageable>(out var damageable))
            {
                Debug.Log("Detected damageable");
                detectedDamageable = damageable;
                return true;
            }

            return false;
        }
    }
}