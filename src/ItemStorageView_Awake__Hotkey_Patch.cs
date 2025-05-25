using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Device;

namespace StorageSort
{
    [HarmonyPatch(typeof(ItemsStorageView), nameof(ItemsStorageView.Awake))]    
    public static class ItemStorageView_Awake__Hotkey_Patch
    {
        public static void Postfix(ItemsStorageView __instance)
        {
            const string GameObjectName = "SortHotkey";

            //screen.DragControllerDropOutsideCallback(item);
            //screen.DragControllerInteractionCallback(InventoryInteractionType.DropOutside);
            //screen.DragControllerRefreshCallback();
            if (__instance.GetComponent<ItemsStorageViewUpdate>() == null)
            {
                ItemsStorageViewUpdate update = __instance.gameObject.AddComponent<ItemsStorageViewUpdate>();
                update.name = GameObjectName;
                update.ItemsStorageView = __instance;
            }
        }   
    }
}
