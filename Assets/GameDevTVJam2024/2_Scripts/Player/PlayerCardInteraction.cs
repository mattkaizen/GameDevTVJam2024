using System.Collections.Generic;
using Data;
using Domain;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Player
{
    public class PlayerCardInteraction : MonoBehaviour
    {
        public UnityEvent CardInteractionFailed;
        
        [Header("Dependencies")]
        [SerializeField] private PlayerMoneyHandler playerMoneyHandler;
        [SerializeField] private PlayerRaycast playerRaycast;
        [SerializeField] private PlayerDragAndDropSystem playerDragAndDropSystem;
        [SerializeField] private InputReaderData inputReaderData;

        private void Awake()
        {
            inputReaderData.SelectDown += OnSelectDown;
            inputReaderData.SelectUp += OnSelectUp;
        }

        private void OnDisable()
        {
            inputReaderData.SelectDown -= OnSelectDown;
            inputReaderData.SelectUp -= OnSelectUp;
        }

        private void OnSelectDown()
        {
            TryInteractWithCards(playerRaycast.GetGraphicRayCastResults());
        }

        private void OnSelectUp()
        {
            playerDragAndDropSystem.StopDragging();
        }

        private void TryInteractWithCards(List<RaycastResult> objetsToInteract)
        {
            foreach (var objectToInteract in objetsToInteract)
            {
                TryInteractWithCard(objectToInteract.gameObject);
            }
        }

        private void TryInteractWithCard(GameObject gameObjectToInteract)
        {
            if (gameObjectToInteract.TryGetComponent<ICardInteractable>(out var cardInteractable))
            {
                if (HasEnoughMoneyToInteract(cardInteractable))
                {
                    playerDragAndDropSystem.StartDraggingRoutine(cardInteractable);
                }
                else
                {
                    CardInteractionFailed?.Invoke();
                }
            }
        }

        private bool HasEnoughMoneyToInteract(ICardInteractable cardInteractable)
        {
            return playerMoneyHandler.CurrentMoney >= cardInteractable.Data.Cost;
        }
    }
}