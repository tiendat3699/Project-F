using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Inventory
{
    [Serializable]
    public class InventorySlotData
    {
        private ItemData _itemData;
        [TableColumnWidth(40, Resizable = false)]
        [ShowInInspector, PreviewField(35)] public Sprite Icon => _itemData?.Icon;
        [ShowInInspector] public string ItemName => _itemData?.ItemName;
        [TableColumnWidth(40, Resizable = false)]
        [ShowInInspector] public int Size => _size;
        public int Capacity => _itemData.Capacity;
        private int _size;

        public InventorySlotData(ItemData itemData)
        {
            _itemData = itemData;
            _size = 1;
        }
        
        public bool CheckEquals(ItemData data)
        {
            return data == _itemData;
        }
        
        /// <summary>
        /// Add item to slot
        /// </summary>
        public void Add()
        {
            _size++;
        }
        
        /// <summary>
        /// Remove item from slot
        /// </summary>
        public void Remove()
        {
            _size--;
        }
    }
}