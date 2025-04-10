using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StorageSort
{
    public class ItemsStorageViewUpdate : MonoBehaviour
    {
        public ItemsStorageView ItemsStorageView { get; set; }

        public static KeyCode SortKey;

        static ItemsStorageViewUpdate()
        {
            SortKey = Plugin.Config.SortKey;    
        }

        public void Update()
        {
            ItemStorage storage = ItemsStorageView?.Storage;
            if (!Input.GetKey(SortKey) || (storage?.Empty ?? true)) return;

            storage.SortWithExpandByTypeAndName(Bootstrap._state.Get<SpaceTime>());
            //Handles the refresh.
            ItemsStorageView.InitContent(storage);
        }

    }
}
