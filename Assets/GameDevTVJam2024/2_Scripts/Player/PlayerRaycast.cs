using System.Collections.Generic;
using Domain;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Player
{
    public class PlayerRaycast : MonoBehaviour
    {
        [SerializeField] private GraphicRaycaster rayCaster;
        [SerializeField] private EventSystem eventSystem;
        private PointerEventData _pointerEventData;

        public List<RaycastResult> GetGraphicRayCastResults()
        {
            _pointerEventData = new PointerEventData(eventSystem);
            _pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            rayCaster.Raycast(_pointerEventData, results);

            return results;
        }
        
        public GameObject RaycastToContainer()
        {
            GameObject container = null;
            RaycastHit2D[] hits = RaycastAllToMousePosition();

            foreach (var hit in hits)
            {
                if (hit.collider == null) continue;

                container = hit.collider.gameObject;

                if (hit.collider.gameObject.TryGetComponent<IUnitContainer>(out var newContainer))
                {
                    break;
                }
            }

            return container;
        }


        public RaycastHit2D[] RaycastAllToMousePosition()
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseWorldPosition2D = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);

            RaycastHit2D[] hits = Physics2D.RaycastAll(mouseWorldPosition2D, Vector2.zero);

            return hits;
        }
    }
}