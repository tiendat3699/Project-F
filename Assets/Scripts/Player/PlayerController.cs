using System;
using Animation;
using Enum;
using Manager;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]private Rigidbody2D _rigidbody;
        [SerializeField] private int _speed;
        [SerializeField] private AnimationHandler _animationHandler;
        [SerializeField] private TileBase _highLightTile;
        private Vector2 _motionMove;
        private GridCellManager _gridCellManager;

        private void Start()
        {
            _gridCellManager = GridCellManager.Instance;
        }

        private void FixedUpdate()
        {
            if (_motionMove == Vector2.zero)
            {
                _rigidbody.velocity = Vector2.zero;
            }
            else if(_motionMove.magnitude > 0.2f)
            {
                _rigidbody.velocity = _motionMove * _speed;
                _animationHandler.SetDirection(_motionMove);
            }
        }

        private void LateUpdate()
        {
            if (_motionMove.magnitude > 0.2f)
            {
            
                _gridCellManager.SetTile(TileMapType.Interactive, null);
                Vector2 hightLightPos = new Vector2(transform.position.x, transform.position.y) + _motionMove;
                _gridCellManager.SetTile(TileMapType.Interactive, _highLightTile, hightLightPos);
                _gridCellManager.SetCurrentCell(hightLightPos);
            }
        }

        private void OnMove(InputValue value)
        {
            Vector2 dir = value.Get<Vector2>();
            _motionMove = dir;
            _animationHandler.SetSpeed(dir.magnitude);
        }

        private void OnAction()
        {
            
        }

        private bool CheckCellAvailable()
        {
            Vector2 center = _gridCellManager.GetCellCenterPosition(TileMapType.Farm);
            Collider2D hitCollider = Physics2D.OverlapCircle(center, 0.1f, LayerMask.GetMask("Plant"));
            return hitCollider == null;
        }
    }
}
