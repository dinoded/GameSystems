using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Zenject;

namespace PickUpSystem.Deprecated
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent<InventoryBarItem> _onInteract;

        private IInputService _inputService;
        private InputAction _interactAction;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _interactAction = _inputService.GetInputAction("Player/Interact");
        }

        private void OnEnable()
        {
            _interactAction.Enable();
        }

        private void OnDisable()
        {
            _interactAction.Disable();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!_interactAction.triggered) return;

           /* if (other.TryGetComponent(out IPickable pickable))
            {
                try
                {
                    var result = await pickable.Interact();
                    Tuple<int, InventoryBarItem> items = (Tuple<int, Inventor   yBarItem>)result;
                    for (int i = 0; i < items.Item1; i++) _onInteract?.Invoke(items.Item2);
                }
                catch (InvalidCastException e)
                {
                    Debug.LogError("Incorrect return type!");
                }
            }*/
        }
    }
}
