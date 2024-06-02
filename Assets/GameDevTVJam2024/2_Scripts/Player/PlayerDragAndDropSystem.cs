using System.Collections;
using Domain;
using UnityEngine;

namespace Player
{
    public class PlayerDragAndDropSystem : MonoBehaviour
    {
        [SerializeField] private PlayerRaycast playerRaycast;
        [SerializeField] private PlayerMoneyHandler playerMoneyHandler;

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

            if (cardInteractable.DropCardUnitOn(container))
            {
                playerMoneyHandler.DeductMoney(cardInteractable.Data.Cost);
            }
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
                if (_currentUnitContainer != null && _currentUnitContainer != unitContainer)
                {
                    ResetContainerPreview();
                    cardInteractable.GetUnit().Display.DisablePreview();
                }

                cardInteractable.GetUnit().RotateUnit(unitContainer.GetContainer().transform.right);
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