using Domain;
using Enemies;
using UnityEngine;

namespace Grid
{
    public class UnitContainer : MonoBehaviour, IUnitContainer
    {
        public bool CanContainUnit => canContainUnit;
        public bool IsAvailable => _isAvailable;
        
        //TODO: It has to have TileType?
        [SerializeField] private bool canContainUnit = true;
        [SerializeField] private Unit containedUnit;
        
        private GameObject _previewObject;
        
        private bool _isAvailable;
        private bool _hasPreviewObject;

        private void OnEnable()
        {
            _isAvailable = true;
        }
        
        private void OnUnitDied()
        {
            ClearContainer();
        }

        public bool Contain(Unit unitToContain)
        {
            if (!canContainUnit) return false;
            if (!_isAvailable) return false;
            
            unitToContain.gameObject.transform.SetParent(gameObject.transform);
            unitToContain.gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            unitToContain.gameObject.transform.localPosition = Vector3.zero;

            containedUnit = unitToContain;
            _isAvailable = false;
            unitToContain.Died.AddListener(OnUnitDied);
            return true;
        }

        public void ShowUnitPreview(Unit unit)
        {
            if (!_isAvailable) return;
            if (_hasPreviewObject) return;

            _previewObject = unit.Display.PreviewObject;
            _previewObject.transform.SetParent(transform);
            _previewObject.transform.up = transform.right;
            _previewObject.transform.localPosition = Vector3.zero;
            _hasPreviewObject = true;
            unit.Display.EnablePreview();
        }

        public void HideUnitPreview(Unit unit)
        {
            unit.Display.DisablePreview();
            _hasPreviewObject = false;
            _previewObject = null;
        }

        public void ClearContainer()
        {
            containedUnit.Died.RemoveListener(OnUnitDied);
            containedUnit = null;
            _isAvailable = true;
        }

        public GameObject GetContainer()
        {
            return gameObject;
        }
    }
}