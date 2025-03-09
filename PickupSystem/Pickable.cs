using Shooting;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace PickUpSystem
{
    public class Pickable : Poolable, IPickable
    {
        [SerializeField] protected InventoryBarItem _inventoryBarItem;
        [SerializeField] protected UnityEvent _onPickUp;
        [SerializeField, Range(1, 100)] protected int _amount = 1;

        public void Initialize (InventoryBarItem inventoryBarItem, int amount)
        {
            this._inventoryBarItem = inventoryBarItem;
            this._amount = amount;
        }

        public async virtual Task<object> Interact()
        {
            _onPickUp.Invoke();
            return await Task.FromResult(new Tuple<int,InventoryBarItem>(_amount, _inventoryBarItem));
        }
    }
}