using System;
using Sirenix.OdinInspector;

namespace Item
{
    [Serializable]
    public class InventoryItemData
    {
        [ShowInInspector] private ItemData _data;
        [ShowInInspector] private int _size;
        public int Size => _size;

        public InventoryItemData(ItemData data)
        {
            _data = data;
            _size++;
        }
        
        /// <summary>
        /// Add item to the stack
        /// </summary>
        public void AddToStack()
        {
            _size++;
        }
        
        /// <summary>
        /// Remove item from the stack
        /// </summary>
        public void RemoveFromStack()
        {
            _size--;
        }
    }
}