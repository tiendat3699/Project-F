using Sirenix.OdinInspector;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "New Item Data", menuName = "SO/Item Data", order = 0)]
    public class ItemData : ScriptableObject
    {
        //Col 1
        [HorizontalGroup("Split", 100)]
        [VerticalGroup("Split/Left")]
        [PreviewField(100), HideLabel] public Sprite Icon;
        
        //Col 2
        [VerticalGroup("Split/Right")]
        [LabelWidth(80)]
        [ReadOnly]
        public string ItemName;
        [VerticalGroup("Split/Right")]
        [LabelWidth(80)]
        public int Capacity;
        [TextArea(5, 10)] public string Description;
    }
}