using Data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Object
{
    public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private GameObject unitPrefab;
        [SerializeField] private InputReaderData inputReader;

        private void OnEnable()
        {
            Initialize();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Begin to Drag");
            DisplayUnit();
        }

        public void OnDrag(PointerEventData eventData)
        {
            MoveUnitToPosition(inputReader.MousePosition);
            Debug.Log("Dragging");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //TODO: Reset the position and disable the game object of the unit when it cannot be placed
            Debug.Log("End Drag");
        }

        private void Initialize()
        {
            if (unitPrefab != null)
                unitPrefab.SetActive(false);
        }

        private void DisplayUnit()
        {
            if (unitPrefab != null)
                unitPrefab.SetActive(true);
        }

        private void MoveUnitToPosition(Vector3 newPosition)
        {
            unitPrefab.transform.position = newPosition;
        }
    }
}