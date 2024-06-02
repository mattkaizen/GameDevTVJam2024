using Data;
using Domain;
using UnityEngine;

namespace Player
{
    public class PlayerObjectPicker : MonoBehaviour
    {
        [SerializeField] private PlayerRaycast raycast;
        [SerializeField] private InputReaderData inputReaderData;

        private void Awake()
        {
            inputReaderData.SelectDown += OnSelectDown;
        }
        
        private void OnDisable()
        {
            inputReaderData.SelectDown -= OnSelectDown;
        }

        private void OnSelectDown()
        {
            TryPickup();
        }

        private void TryPickup()
        {
            RaycastHit2D[] hits = raycast.RaycastAllToMousePosition();
            
            foreach (var hit in hits)
            {
                if (hit.collider == null) continue;
                
                if (hit.collider.gameObject.TryGetComponent<IPickable>(out var pickable))
                {
                    pickable.Pickup();
                }
            }
        }
    }
}