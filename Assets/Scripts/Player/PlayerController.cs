using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private int _speed;
    [SerializeField] private AnimtionHandler _animtionHandler;
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Transform _hightLight;
    [SerializeField] private RuleTile _farmTile;
    private Vector2 _motionMove;
    private Camera _camera;
    
    private void Start()
    {
        _camera = Camera.main;
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
            _animtionHandler.SetDirection(_motionMove);
        }
    }

    private void LateUpdate()
    {
        if (_motionMove.magnitude > 0.2f)
        {
            Vector2 hightLightPos = new Vector2(transform.position.x, transform.position.y) + _motionMove + Vector2.down;
            Vector3Int cellPosition = _tilemap.WorldToCell(hightLightPos);
            _hightLight.position = _tilemap.GetCellCenterWorld(cellPosition);
        }
    }

    private void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>();
        _motionMove = dir;
        _animtionHandler.SetSpeed(dir.magnitude);
    }
    

    // private void OnMouse(InputValue value)
    // {
    //     Vector2 mousePos = value.Get<Vector2>();
    //     Vector3Int cellPosition = _tilemap.WorldToCell(_camera.ScreenToWorldPoint(mousePos));
    //     _hightLight.position = _tilemap.GetCellCenterWorld(cellPosition);
    // }

    private void OnClick()
    {
        Vector3Int cellPosition = _tilemap.WorldToCell(_hightLight.position);
        _tilemap.SetTile(cellPosition, _farmTile);
    }
}
