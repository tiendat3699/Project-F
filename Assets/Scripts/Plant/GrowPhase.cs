using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Plant
{
    [Serializable]
    public class GrowPhase
    {
        [TableColumnWidth(50, Resizable = false)]
        [PreviewField(40, ObjectFieldAlignment.Center)] public Sprite Sprite;
        [Tooltip("Phase Time in seconds")]
        public float PhaseTime;
    }
}
