using System;
using System.Collections.Generic;
using Item;
using Pool;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "SO/GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [AssetList(Path = "SO/Items")]
        public ItemData[] ItemDatas;
    }
}