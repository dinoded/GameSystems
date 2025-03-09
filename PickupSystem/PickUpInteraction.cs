using Interactions;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace PickUpSystem.Interaction
{
    public class PickUpInteraction : PlayerInteraction<IPickable>
    {
        [SerializeField] private UnityEvent<InventoryBarItem> _onInteraction;

        protected async override void HandleInteraction(IPickable interactable)
        {
            try
            {
                var result = await interactable.Interact();
                Tuple<int, InventoryBarItem> item = (Tuple<int, InventoryBarItem>)result;
                for (int i = 0; i < item.Item1;i++) _onInteraction?.Invoke(item.Item2);
            }
            catch (InvalidCastException e)
            {
                Debug.LogError($"Unable to interact");
            }
            
        }
    }
}
