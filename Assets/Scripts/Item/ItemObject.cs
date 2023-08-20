using System;
using Manager;
using UnityEngine;

namespace Item
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class ItemObject : MonoBehaviour
    {
        private InventoryManager _inventoryManager;
        public ItemData Data { get; set; }
        
        public abstract void Use();

        public void Pick()
        {
            _inventoryManager.PickItem(Data);
        }

        public void Drop()
        {
            _inventoryManager.RemoveItem(Data);
        }
        
        private void Collect()
        {
            _inventoryManager.AddItem(Data);
        }

        protected virtual void Awake()
        {
            _inventoryManager = InventoryManager.Instance;
        }
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            Collect();
            ItemManager.Instance.ReleaseItem(this);
        }
    }
}