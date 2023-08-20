using System;
using Enum;
using Item;
using Manager;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Plant
{
    public class Seed : ItemObject
    {
        [AssetSelector(Paths = "Assets/Prefabs/Plants")]
        [SerializeField] private PlantBase _plant;
        private GridCellManager _gridCellManager;

        protected override void Awake()
        {
            base.Awake();
            _gridCellManager = GridCellManager.Instance;
        }

        public override void Use()
        {
            Vector2 plantPos = _gridCellManager.GetCellCenterPosition(TileMapType.Farm);
            Instantiate(_plant, plantPos, Quaternion.identity);
        }
    }
}