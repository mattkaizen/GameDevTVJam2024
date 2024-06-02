using UnityEngine;

namespace Enemies
{
    public class UnitDisplay : MonoBehaviour
    {
        public GameObject PreviewObject
        {
            get => previewObject;
            set => previewObject = value;
        }
        
        [SerializeField] private GameObject previewObject;
        [SerializeField] private SpriteRenderer unitSprite;
        
        public void EnablePreview()
        {
            previewObject.SetActive(true);
        }

        public void DisablePreview()
        {
            previewObject.SetActive(false);
        }

        public void EnableUnitSprite()
        {
            unitSprite.enabled = true;
        }

        public void DisableUnitSprite()
        {
            unitSprite.enabled = false;
        }
        
    }
}