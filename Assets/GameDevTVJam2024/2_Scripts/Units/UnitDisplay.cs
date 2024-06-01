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

        public void EnablePreview()
        {
            previewObject.SetActive(true);
        }

        public void DisablePreview()
        {
            previewObject.SetActive(false);

        }
    }
}