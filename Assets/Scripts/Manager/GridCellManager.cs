using System.Collections.Generic;
using Enum;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;
using Utilities;

namespace Manager
{
    public class GridCellManager : PersistentSingleton<GridCellManager>
    {
        [ShowInInspector] private Dictionary<TileMapType, Tilemap> _tilemaps = new Dictionary<TileMapType, Tilemap>();
        private Vector2 _currentCellPosition;
        
        /// <summary>
        /// Set current cell Position in world space
        /// </summary>
        /// <param name="position">World position to set</param>
        public void SetCurrentCell(Vector2 position)
        {
            _currentCellPosition = position;
        }
        
        /// <summary>
        /// Add new tile map to manager
        /// </summary>
        /// <param name="tileMapType">Tile map type</param>
        /// <param name="tilemap">Tile map to add</param>
        public void AddTileMap(TileMapType tileMapType, Tilemap tilemap)
        {
            _tilemaps.Add(tileMapType, tilemap);
        }
        
        /// <summary>
        /// Remove the tile map in manager
        /// </summary>
        /// <param name="tileMapType">Tile map type to remove</param>
        public void RemoveTileMap(TileMapType tileMapType)
        {
            _tilemaps.Remove(tileMapType);
        }
        
        /// <summary>
        /// Get the tile at the current cell in the tile map
        /// </summary>
        /// <param name="tileMapType">Tile map type to get the tile</param>
        /// <returns>TileBase at current cell</returns>
        public TileBase GetTile(TileMapType tileMapType)
        {
            Vector3Int cellPosition = _tilemaps[tileMapType].WorldToCell(_currentCellPosition);
            return _tilemaps[tileMapType].GetTile(cellPosition);
        }
        
        /// <summary>
        /// Get the tile at the given position of cell in the tile map
        /// </summary>
        /// <param name="tileMapType">Tile map type to get the tile</param>
        /// <param name="position">Position to get the tile</param>
        /// <returns>TileBase at current cell</returns>
        public TileBase GetTile(TileMapType tileMapType, Vector2 position)
        {
            Vector3Int cellPosition = _tilemaps[tileMapType].WorldToCell(position);
            return _tilemaps[tileMapType].GetTile(cellPosition);
        }
        
        /// <summary>
        /// Set the tile at the current cell in the tile map
        /// </summary>
        /// <param name="tileMapType">Tile map type to set the tile</param>
        /// <param name="tileBase">The tile map to place in the current cell</param>
        public void SetTile(TileMapType tileMapType, TileBase tileBase)
        {
            Vector3Int cellPosition = _tilemaps[tileMapType].WorldToCell(_currentCellPosition);
            _tilemaps[tileMapType].SetTile(cellPosition, tileBase);
        }
        
        /// <summary>
        /// Set the tile at given position of cell in the tile map
        /// </summary>
        /// <param name="tileMapType">Tile map type to set the tile</param>
        /// <param name="tileBase">The tile map to place at the position</param>
        /// <param name="position">Position of the tile in the tile map</param>
        public void SetTile(TileMapType tileMapType, TileBase tileBase, Vector2 position)
        {
            Vector3Int cellPosition = _tilemaps[tileMapType].WorldToCell(position);
            _tilemaps[tileMapType].SetTile(cellPosition, tileBase);
        }
        
        /// <summary>
        /// Gets the center of a current cell in world space
        /// </summary>
        /// <param name="tileMapType">Tile map type to get center</param>
        /// <returns>Center of the cell in world space</returns>
        public Vector2 GetCellCenterPosition(TileMapType tileMapType)
        {
            Vector3Int cellPosition = _tilemaps[tileMapType].WorldToCell(_currentCellPosition);
            return _tilemaps[tileMapType].GetCellCenterWorld(cellPosition);
        }

        /// <summary>
        /// Get the center of cell at given position in world space
        /// </summary>
        /// <param name="tileMapType">Tile map type to get center</param>
        /// <param name="position">Position to get center of cell</param>
        /// <returns>Center of cell in world space</returns>
        public Vector2 GetCellCenterPosition(TileMapType tileMapType, Vector2 position)
        {
            Vector3Int cellPosition = _tilemaps[tileMapType].WorldToCell(position);
            return _tilemaps[tileMapType].GetCellCenterWorld(cellPosition);
        }
        

    }
}