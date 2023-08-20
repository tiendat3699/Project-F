using Sirenix.OdinInspector;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "NewItemData", menuName = "SO/ItemData", order = 0)]
    public class ItemData : ScriptableObject
    {
        public string ItemName;
        [AssetSelector(Paths = "Assets/Prefabs/ItemObject")]
        public ItemObject Prefab;
        [PreviewField] public Sprite Icon;
    }
}