using System;
using Enum;
using Manager;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

namespace Environment
{
    [RequireComponent(typeof(Tilemap))]
    public class TileMapObject : MonoBehaviour
    {
        [SerializeField] private TileMapType _type;
        private GridCellManager _gridCellManager;

        private void Awake()
        {
            _gridCellManager = GridCellManager.Instance;
        }

        private void OnEnable()
        {
            _gridCellManager.AddTileMap(_type, GetComponent<Tilemap>());
        }

        private void OnDisable()
        {
            _gridCellManager.RemoveTileMap(_type);
        }
    }
}