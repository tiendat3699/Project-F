using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Plant
{
    public class PlantBase : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField, PreviewField(40)] private Sprite _harvestedSprite , _deadSprite;
        [SerializeField, TableList(ShowIndexLabels = true)] private GrowPhase[] _grownPhases;
        private int _currentPhase;
        private float _timer;

        private void Start()
        {
            _spriteRenderer.sprite = _grownPhases[0].Sprite;
            _currentPhase = 0;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_currentPhase < _grownPhases.Length - 1 && _timer >= _grownPhases[_currentPhase].PhaseTime)
            {
                _currentPhase++;
                _timer = 0;
                _spriteRenderer.sprite = _grownPhases[_currentPhase].Sprite;
            }
        }
    }
}
