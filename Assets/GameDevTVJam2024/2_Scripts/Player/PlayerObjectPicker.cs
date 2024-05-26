using Data;
using UnityEngine;

namespace Player
{
    public class PlayerObjectPicker : MonoBehaviour
    {
        [SerializeField] private GameObject pickedObject;
        [SerializeField] private InputReaderData inputReader;

        private void OnEnable()
        {
            inputReader.Selected += OnSelect;
        }

        private void OnSelect()
        {
        }

        private bool _hasObject;
        
        private void TryPickup(GameObject item)
        {
            
        }
    }
}