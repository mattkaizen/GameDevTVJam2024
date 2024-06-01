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
        [SerializeField] private GameObject containedObject;
        
        private GameObject _previewObject;
        
        private bool _isAvailable;
        private bool _hasPreviewObject;

        private void OnEnable()
        {
            _isAvailable = true;
        }

        public bool Contain(GameObject objectToContain)
        {
            if (!canContainUnit) return false;
            if (!_isAvailable) return false;
            
            objectToContain.transform.SetParent(gameObject.transform);
            objectToContain.transform.localRotation = Quaternion.Euler(Vector3.zero);
            objectToContain.transform.localPosition = Vector3.zero;

            containedObject = objectToContain;
            _isAvailable = false;
            return true;
        }
        
        public void ShowUnitPreview(Unit unit)
        {
            if (!_isAvailable) return;
            if (_hasPreviewObject) return;

            _previewObject = unit.Display.PreviewObject;
            _previewObject.transform.SetParent(transform);
            _previewObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            _previewObject.transform.localPosition = Vector3.zero;
            _hasPreviewObject = true;
            unit.Display.EnablePreview();
        }

        public void HideUnitPreview()
        {
            _hasPreviewObject = false;
            _previewObject = null;
        }

        public void ClearContainer()
        {
            containedObject.SetActive(false);
            containedObject = null;
            _isAvailable = true;
        }
    }
}