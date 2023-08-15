using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimtionHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private int _directionXHash, _directionYHash, _speedHash;

    private void Awake()
    {
        _directionXHash = Animator.StringToHash("DirectionX");
        _directionYHash = Animator.StringToHash("DirectionY");
        _speedHash = Animator.StringToHash("Speed");
    }

    public void SetDirection(Vector2 dir)
    {
        _animator.SetFloat(_directionXHash, dir.x);
        _animator.SetFloat(_directionYHash, dir.y);
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(_speedHash, speed);
    }
}
