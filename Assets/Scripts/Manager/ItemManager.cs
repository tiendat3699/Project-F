using System.Collections.Generic;
using Config;
using Cysharp.Threading.Tasks;
using Item;
using Pool;
using UnityEngine;
using Utilities;

namespace Manager
{
    public class ItemManager : Singleton<ItemManager>
    {
        private Dictionary<ItemData, PoolBase<ItemObject>> _dictionaryPool = new Dictionary<ItemData, PoolBase<ItemObject>>();
        
        protected override async void Awake()
        {
            base.Awake();
            var gameConfig = await Resources.LoadAsync("Config/GameConfig") as GameConfig;
            if (gameConfig == null) return;
            foreach (var itemData in gameConfig.ItemDatas)
            {
                var pool = new PoolBase<ItemObject>(itemData.Prefab);
                _dictionaryPool.Add(itemData, pool);
            }
        }
        
        /// <summary>
        /// Get item from manager
        /// </summary>
        /// <param name="data">ScriptableObject data reference for the item to get</param>
        /// <returns>Item object</returns>
        public ItemObject SpawnItem(ItemData data)
        {
            var item = _dictionaryPool[data].Spawn();
            item.Data = data;
            return item;
        }
        
        /// <summary>
        /// Get item from manager with given position and rotation
        /// </summary>
        /// <param name="data">ScriptableObject data reference for the item to get</param>
        /// <param name="position">Position to place the item</param>
        /// <param name="rotation">Rotation of item</param>
        /// <returns>Item object</returns>
        public ItemObject SpawnItem(ItemData data, Vector2 position, Quaternion rotation)
        {
            return _dictionaryPool[data].Spawn(position, rotation);
        }
        
        /// <summary>
        /// Deactivate the item
        /// </summary>
        /// <param name="item">Item to release</param>
        public void ReleaseItem(ItemObject item)
        {
            _dictionaryPool[item.Data].Release(item);
        }
    }
}