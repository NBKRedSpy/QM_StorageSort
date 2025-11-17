using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MGSC;
using UnityEngine;

namespace StorageSort.Patches.DropAndSort
{

    /// <summary>
    /// ItemsStorageView doesn't have an update, so attach an update handler to it to process hotkeys.
    /// </summary>
    [HarmonyPatch(typeof(ItemsStorageView), nameof(ItemsStorageView.Awake))]    
    public static class ItemStorageView_Awake__Hotkey_Patch
    {
        public static void Postfix(ItemsStorageView __instance)
        {
            const string GameObjectName = "SortHotkey";

            if (__instance.GetComponent<ItemsStorageViewUpdate>() == null)
            {
                ItemsStorageViewUpdate update = __instance.gameObject.AddComponent<ItemsStorageViewUpdate>();
                update.name = GameObjectName;
                update.ItemsStorageView = __instance;
            }
        }   
    }
}
