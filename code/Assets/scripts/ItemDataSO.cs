using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
    // Copyright 
    // Created by Sami S. use of any kind without a written permission from the author is not allowed.
    // But feel free to take a look.

    // Item assets data --------

    [CreateAssetMenu(menuName = "ItemSystem/ItemData")]
    public class ItemDataSO : ScriptableObject
    {
        [Header("Runtime")]
        public ItemData data;

        public Sprite assetSprite;
        public GameObject assetPrefab;
        public AudioClip assetSound;
    }

}