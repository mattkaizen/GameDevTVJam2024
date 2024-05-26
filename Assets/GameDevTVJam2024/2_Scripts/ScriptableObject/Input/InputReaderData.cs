using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Data
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "InputReader", fileName = "InputReaderData")]
    public class InputReaderData : ScriptableObject, GameControls.IPlayerActions
    {
        public event UnityAction Selected = delegate { };
        public event UnityAction Cancel = delegate { };
        public Vector2 MousePosition => _mousePosition;

        private Vector2 _mousePosition;
        private GameControls _playerInputActions;

        private void OnEnable()
        {
            _playerInputActions = new GameControls();
            _playerInputActions.Player.Enable();
            _playerInputActions.Player.SetCallbacks(this);

            _playerInputActions.Player.Select.performed += OnSelect;
            _playerInputActions.Player.MousePosition.performed += OnMousePosition;
            _playerInputActions.Player.Cancel.performed += OnCancel;
        }

        private void OnDisable()
        {
            _playerInputActions.Player.Select.performed -= OnSelect;
            _playerInputActions.Player.MousePosition.performed -= OnMousePosition;
            _playerInputActions.Player.Cancel.performed -= OnCancel;
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            if (_playerInputActions.Player.Select.WasPerformedThisFrame())
            {
                Selected?.Invoke();
            }
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            if (_playerInputActions.Player.Cancel.WasPerformedThisFrame())
            {
                Cancel?.Invoke();
            }
        }

        public void OnMousePosition(InputAction.CallbackContext context)
        {
            if (_playerInputActions.Player.MousePosition.WasPerformedThisFrame())
            {
                _mousePosition = context.ReadValue<Vector2>();
            }
        }
    }
}