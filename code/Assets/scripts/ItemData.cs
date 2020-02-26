using UnityEngine;

namespace ItemSystem
{
    // Copyright 
    // Created by Sami S. use of any kind without a written permission from the author is not allowed.
    // But feel free to take a look.

    // Runtime item data ------

    [System.Serializable]
    public class ItemData
    {
        public string itemID;
        public int vendorValue;
        public Vector3 worldPosition;

        public ItemData Clone()
        {
            return (ItemData)(this).MemberwiseClone();
        }
    }

}