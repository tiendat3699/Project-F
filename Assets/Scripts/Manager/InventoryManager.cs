using System.Linq;
using System.Collections.Generic;
using Inventory;
using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;

namespace Manager
{
    public class InventoryManager : PersistentSingleton<InventoryManager>
    {
        /// <summary>
        /// The item is currently being picked
        /// </summary>
        public ItemData CurrentItem { get; private set; }
        
        [SerializeField] private int _maxSlot;
        [TableList, SerializeField] private List<InventorySlotData> _inventorySlots = new List<InventorySlotData>();

        /// <summary>
        /// Add new item to inventory
        /// </summary>
        /// <param name="data">ScriptableObject data reference for the item to be added</param>
        public void AddItem(ItemData data)
        {
            var slots = _inventorySlots.Where((slot) => slot.CheckEquals(data) && slot.Size < slot.Capacity);
            var inventorySlotDatas = slots.ToList();
            if (inventorySlotDatas.Count == 0)
            {
                if (_inventorySlots.Count < _maxSlot)
                {
                    AddNewSlot(data);
                }
            }
            else
            {
                inventorySlotDatas.Last().Add();
            }
        }
        
        /// <summary>
        /// Add new item to inventory with given quantity
        /// </summary>
        /// <param name="data">ScriptableObject data reference for the item to be added</param>
        /// <param name="quantity">Number of items to add</param>
        [Button]
        public void AddItem(ItemData data, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                AddItem(data);
            }
        }
        
        /// <summary>
        /// Remove item form inventory
        /// </summary>
        /// <param name="data">ScriptableObject data reference for the item to be removed</param>
        public void RemoveItem(ItemData data)
        {
            var slots = _inventorySlots.Where((slot) => slot.CheckEquals(data));
            var inventorySlotDatas = slots.ToList();
            if (inventorySlotDatas.Count > 0)
            {
                var slot = inventorySlotDatas.Last();
                if (slot.Size > 1)
                {
                    slot.Remove();
                }
                else
                {
                    _inventorySlots.Remove(slot);
                }
            }
        }
        
        /// <summary>
        /// Remove item from inventory with given quantity
        /// </summary>
        /// <param name="data">ScriptableObject data reference for the item to be removed</param>
        /// <param name="quantity">Number of items to remove</param>
        [Button]
        public void RemoveItem(ItemData data, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                RemoveItem(data);
            }
        }
        
        /// <summary>
        /// Pick up item from inventory, you can access it using CurrentItem
        /// </summary>
        /// <param name="data">ScriptableObject data reference for the item to be added</param>
        public void PickItem(ItemData data)
        {
            CurrentItem = data;
        }

        private void AddNewSlot(ItemData data)
        {
            _inventorySlots.Add(new InventorySlotData(data));
        }
    }
}