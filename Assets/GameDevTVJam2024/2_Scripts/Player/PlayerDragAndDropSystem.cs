using System.Collections;
using Domain;
using UnityEngine;

namespace Player
{
    public class PlayerDragAndDropSystem : MonoBehaviour
    {
        [SerializeField] private PlayerRaycast playerRaycast;

        private IUnitContainer _currentUnitContainer;
        private IEnumerator _draggingCardRoutine;
        private bool _isDraggingACard;
        
        public void StartDraggingRoutine(ICardInteractable cardInteractable)
        {
            _draggingCardRoutine = DragCardRoutine(cardInteractable);

            StartCoroutine(_draggingCardRoutine);
        }

        public void StopDragging()
        {
            _isDraggingACard = false;
        }

        private IEnumerator DragCardRoutine(ICardInteractable cardInteractable)
        {
            cardInteractable.InitializeCardUnit();
            _isDraggingACard = true;

            while (_isDraggingACard)
            {
                cardInteractable.DragCardUnit();
                ShowUnitPreviewIfOverContainer(cardInteractable);
                yield return null;
            }

            TryContainCardUnit(cardInteractable);
        }

        private void TryContainCardUnit(ICardInteractable cardInteractable)
        {
            var container = playerRaycast.RaycastToContainer();

            cardInteractable.DropCardUnitOn(container);
        }

        private void ShowUnitPreviewIfOverContainer(ICardInteractable cardInteractable)
        {
            var container = playerRaycast.RaycastToContainer();

            if (container == null)
            {
                ResetContainerPreview();
                cardInteractable.GetUnit().Display.DisablePreview();
                return;
            }

            if (container.TryGetComponent<IUnitContainer>(out var unitContainer) && unitContainer.CanContainUnit && unitContainer.IsAvailable)
            {
                _currentUnitContainer = unitContainer;
                unitContainer.ShowUnitPreview(cardInteractable.GetUnit());
            }
            else
            {
                ResetContainerPreview();
                cardInteractable.GetUnit().Display.DisablePreview();
            }
        }

        private void ResetContainerPreview()
        {
            if (_currentUnitContainer == null) return;
            
            _currentUnitContainer.HideUnitPreview();
            _currentUnitContainer = null;
        }
    }
}