using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace ItemSystem
{
    // Copyright 
    // Created by Sami S. use of any kind without a written permission from the author is not allowed.
    // But feel free to take a look.
    
    [CustomEditor(typeof(ItemDataSO))]
    public class ItemDataSOEditor : Editor
    {

        void OnEnable()
        {
        }

        public override void OnInspectorGUI()
        {
            // Debug
            // DrawDefaultInspector();

            serializedObject.Update();

            var item = serializedObject.FindProperty("data");
            var itemID = item.FindPropertyRelative("itemID");
            var vendorValue = item.FindPropertyRelative("vendorValue");
            var worldPosition = item.FindPropertyRelative("worldPosition");
            var sprite = serializedObject.FindProperty("assetSprite");
            var prefab = serializedObject.FindProperty("assetPrefab");
            var sound = serializedObject.FindProperty("assetSound");


            using (var block = new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                sprite.objectReferenceValue = EditorGUILayout.ObjectField(sprite.objectReferenceValue, typeof(Sprite),
                allowSceneObjects: false, GUILayout.Height(70), GUILayout.Width(70));

                EditorGUILayout.LabelField("Sprite:", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(sprite);
            }

            using (var block = new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                EditorGUILayout.LabelField("Prefab:", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(prefab);
            }

            using (var block = new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                EditorGUILayout.LabelField("Sound:", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(sound);
            }

            using (var block = new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                EditorGUILayout.LabelField("Item Data:", EditorStyles.boldLabel);

                // EditorGUILayout.PropertyField(item, true);
                EditorGUILayout.PropertyField(itemID);
                EditorGUILayout.PropertyField(vendorValue);
                EditorGUILayout.PropertyField(worldPosition);
            }

            // for serialized class
            serializedObject.ApplyModifiedProperties();
        }


        void OnDisable()
        {
        }

    }

}