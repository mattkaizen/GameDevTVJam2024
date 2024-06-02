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
        [SerializeField] private InteractableCardDisplay display;

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
            display.UpdateCostText(cardData.Cost.ToString());
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

        public bool DropCardUnitOn(GameObject objectToDropOn)
        {
            if (objectToDropOn == null)
            {
                HideUnit();
                return false;
            }

            if (objectToDropOn.TryGetComponent<IUnitContainer>(out var container))
            {
                if (!container.Contain(GetUnit()))
                {
                    HideUnit();
                    return false;
                }
                
                GetUnit().RotateUnit(container.GetContainer().transform.right);
                container.HideUnitPreview(GetUnit());
                GetUnit().EnableCharacterBehaviour();
                _instantiatedUnit = null;
                return true;
            }

            HideUnit();
            return false;
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