using System.Collections.Generic;
using Item;
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
        [ShowInInspector] private Dictionary<ItemData, InventoryItemData> _inventoryItems = new Dictionary<ItemData, InventoryItemData>();
        
        /// <summary>
        /// Add new item to inventory
        /// </summary>
        /// <param name="data">ScriptableObject data reference for the item to be added</param>
        public void AddItem(ItemData data)
        {
            if (_inventoryItems.TryGetValue(data, out var item))
            {
                item.AddToStack();
            }
            else
            {
                _inventoryItems.Add(data, new InventoryItemData(data));
            }
        }
        
        /// <summary>
        /// Remove item form inventory
        /// </summary>
        /// <param name="data">ScriptableObject data reference for the item to be added</param>
        public void RemoveItem(ItemData data)
        {
            if (_inventoryItems.TryGetValue(data, out var item))
            {
                if (item.Size > 1)
                {
                    item.RemoveFromStack();
                }
                else
                {
                    _inventoryItems.Remove(data);
                }
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
    }
}