using Data;
using Domain;
using Enemies;
using UnityEngine;

namespace Object
{
    public class InteractableCard : MonoBehaviour, ICardInteractable
    {
        [SerializeField] private CardData cardData;
        [SerializeField] private InputReaderData inputReader;

        private GameObject _instantiatedUnit;
        private bool _isBeingDragged;

        public CardData Data
        {
            get => cardData;
            set => cardData = value;
        }

        private void OnEnable()
        {
            GameObject unitObject = GetUnitObject();
            unitObject.SetActive(false);
        }

        public GameObject GetUnitObject()
        {
            if (_instantiatedUnit == null)
                SpawnUnitPrefab();

            return _instantiatedUnit;
        }

        private void SpawnUnitPrefab()
        {
            _instantiatedUnit = Instantiate(cardData.UnitPrefab);
        }

        public Unit GetUnit()
        {
            Unit unit = null;

            if (GetUnitObject().TryGetComponent<Unit>(out var currentUnit))
            {
                unit = currentUnit;
            }

            return unit;
        }

        public void InitializeCardUnit()
        {
            GameObject unit = GetUnitObject();
            unit.transform.localPosition = Vector3.zero;
            unit.transform.localRotation = Quaternion.Euler(Vector3.zero);
            DisplayUnit();
        }

        public void DragCardUnit()
        {
            MoveUnitToMouseWorldPosition();
        }

        public void DropCardUnitOn(GameObject objectToDropOn)
        {
            if (objectToDropOn == null)
            {
                HideUnit();
                return;
            }

            if (objectToDropOn.TryGetComponent<IUnitContainer>(out var container) && container.IsAvailable)
            {
                container.Contain(_instantiatedUnit);
                container.HideUnitPreview();
                GetUnit().EnableUnitBehaviour();
                _instantiatedUnit = null;
            }
            else
            {
                HideUnit();
            }
        }

        private void DisplayUnit()
        {
            _instantiatedUnit.SetActive(true);
        }

        private void HideUnit()
        {
            _instantiatedUnit.SetActive(false);
        }

        private void MoveUnitToMouseWorldPosition()
        {
            var mouseWorldPosition = Camera.main.ScreenToWorldPoint(inputReader.MousePosition);
            mouseWorldPosition.z = 0;
            _instantiatedUnit.transform.position = mouseWorldPosition;
        }
    }
}