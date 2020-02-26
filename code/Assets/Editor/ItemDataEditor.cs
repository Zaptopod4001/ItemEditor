using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace ItemSystem
{
    // Copyright 
    // Created by Sami S. use of any kind without a written permission from the author is not allowed.
    // But feel free to take a look.

    class ItemDataEditor : EditorWindow
    {

        // Local ----------

        string[] assetGuids;
        string newName = "Item";
        string newAssetName = "Item";
        ItemDataSO selected;
        int index;



        // Init -----------

        [MenuItem("Window/Items Editor")]
        public static void ShowWindow()
        {
            var window = EditorWindow.GetWindow(typeof(ItemDataEditor), false, "Item editor");
            window.minSize = new Vector2(300, 490);
            window.maxSize = new Vector2(600, 600);
        }

        void Awake()
        {
            FindItemAssets();
        }



        // Main -----------

        void OnGUI()
        {

            index = Mathf.Clamp(index, 0, assetGuids.Length - 1);


            // heading -----

            if (assetGuids != null)
            {
                selected = GetSelectedItem();
                var str = "Selected: " + selected.name + " " + (index + 1) + "/" + assetGuids.Length;
                EditorGUILayout.LabelField(str, EditorStyles.boldLabel);
            }
            else
            {
                EditorGUILayout.LabelField("Item:");
            }



            // Change selected -----

            using (var group = new EditorGUILayout.HorizontalScope(GUI.skin.box))
            {
                if (GUILayout.Button("<<"))
                    index--;

                if (GUILayout.Button(">>"))
                    index++;

                if (index < 0)
                    index = assetGuids.Length - 1;

                if (index >= assetGuids.Length)
                    index = 0;

                selected = GetSelectedItem();
            }



            // Add new -----------

            GUILayout.Label("Add new item:", EditorStyles.boldLabel);

            using (var group = new EditorGUILayout.HorizontalScope(GUI.skin.box))
            {
                var folder = GUILayout.TextField("data_items/");
                newName = GUILayout.TextField(newName);

                if (GUILayout.Button("Add Item", EditorStyles.miniButtonLeft) && !string.IsNullOrEmpty(newName))
                {
                    string path = AssetDatabase.GenerateUniqueAssetPath("Assets/" + folder + newName + ".asset");
                    newName = string.Empty;

                    var dir = Path.GetDirectoryName(path);

                    if (AssetDatabase.IsValidFolder(dir))
                    {
                        CreateNewItem(path);
                        FindItemAssets();
                        selected = AssetDatabase.LoadAssetAtPath<ItemDataSO>(path);
                        index = GetItemIndex(selected);
                    }
                }

            }



            // Rename asset ------

            GUILayout.Label("Rename item asset:", EditorStyles.boldLabel);

            using (var group = new EditorGUILayout.HorizontalScope(GUI.skin.box))
            {
                newAssetName = GUILayout.TextField(newAssetName);

                if (GUILayout.Button("Rename Asset", EditorStyles.miniButtonLeft) && !string.IsNullOrEmpty(newAssetName))
                {
                    var item = GetSelectedItem();
                    RenameAsset(item, newAssetName);
                }
            }



            // Draw item ----

            if (selected != null)
            {
                // Draw item editor / inspector
                DrawItemInspector();

                // Delete selected asset button
                if (GUILayout.Button("DELETE SELECTED", GUILayout.Height(40)))
                {
                    DeleteItemAsset();
                    FindItemAssets();

                    // set index
                    index = Mathf.Clamp(--index, 0, assetGuids.Length - 1);
                }
            }

        }



        // Draw item ------

        void DrawItemInspector()
        {
            // Draw inspector for item if exists
            if (selected != null)
            {
                using (var group = new EditorGUILayout.VerticalScope(GUI.skin.box))
                {
                    ItemDataSOEditor editor = (ItemDataSOEditor)Editor.CreateEditor(selected);
                    editor.OnInspectorGUI();
                }
            }
        }



        // CRUD -----------

        void RenameAsset(ItemDataSO item, string newName)
        {
            Debug.Log("RenameAsset: " + item.data.itemID + " to: " + newName);
            var path = AssetDatabase.GetAssetPath(item);

            AssetDatabase.Refresh();
            AssetDatabase.RenameAsset(path, newName);
            AssetDatabase.SaveAssets();
        }

        void CreateNewItem(string path)
        {
            var newItem = ScriptableObject.CreateInstance<ItemDataSO>();
            AssetDatabase.CreateAsset(newItem, path);
            AssetDatabase.SaveAssets();
        }

        string GuidToAssetName(string guid)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var name = Path.GetFileNameWithoutExtension(path);
            return name;
        }

        void DeleteItemAsset()
        {
            Undo.RegisterCompleteObjectUndo(selected, "Delete Asset");

            var path = AssetDatabase.GetAssetPath(selected);
            AssetDatabase.DeleteAsset(path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        void FindItemAssets()
        {
            assetGuids = AssetDatabase.FindAssets("t:ItemDataSO");
        }

        ItemDataSO GetSelectedItem()
        {
            var path = AssetDatabase.GUIDToAssetPath(assetGuids[index]);
            selected = AssetDatabase.LoadAssetAtPath<ItemDataSO>(path);

            if (selected == null)
            {
                path = AssetDatabase.GUIDToAssetPath(assetGuids[index]);
                selected = AssetDatabase.LoadAssetAtPath<ItemDataSO>(path);
            }

            return selected;
        }

        int GetItemIndex(ItemDataSO item)
        {
            var asset = AssetDatabase.GetAssetPath(item);
            var fileName = Path.GetFileName(asset);
            fileName = fileName.Replace(".asset", "");

            for (int i = 0; i < assetGuids.Length; i++)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(assetGuids[i]);
                var assetName = Path.GetFileNameWithoutExtension(assetPath);
                assetName = assetName.Replace(".asset", "");

                if (fileName == assetName)
                    return i;
            }

            return 0;
        }

    }

}
