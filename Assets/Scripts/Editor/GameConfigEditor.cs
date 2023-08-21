using Inventory;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class GameConfigEditor : OdinMenuEditorWindow
    {
        private const string PATH = "Assets/SO/Items";
        
        [MenuItem("Tools/Game config")]
        private static void OpenWindow()
        {
            GetWindow<GameConfigEditor>().Show();
        }
        
        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree();
            tree.Add("Create New", new CreateNewItemData());
            tree.AddAllAssetsAtPath("Item Data", PATH, typeof(ItemData));
            
            return tree;
        }

        private class CreateNewItemData
        {
            [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
            public ItemData ItemData;

            public CreateNewItemData()
            {
                ItemData = CreateInstance<ItemData>();
                ItemData.ItemName = "New Item Data";
            }
            
            [Button("Add New Item SO")]
            private void CreateNewData()
            {
                AssetDatabase.CreateAsset(ItemData, $"{PATH}/{ItemData.ItemName}.asset");
                AssetDatabase.SaveAssets();
            }
        }
    }
}