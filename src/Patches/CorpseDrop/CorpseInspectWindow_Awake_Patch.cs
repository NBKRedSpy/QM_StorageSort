using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MGSC;
using StorageSort.Patches.BackpackSort;
using UnityEngine;

namespace StorageSort.Patches.DropAndSort
{

    /// <summary>
    /// ItemsStorageView doesn't have an update, so attach an update handler to it to process hotkeys.
    /// </summary>
    [HarmonyPatch(typeof(CorpseInspectWindow), nameof(CorpseInspectWindow.Awake))]    
    public static class CorpseInspectWindow_Awake_Patch
    {
        public static void Postfix(CorpseInspectWindow  __instance)
        {
            CorpseInspectWindowComponent.CreateComponent<CorpseInspectWindowComponent>(__instance);
        }   
    }
}
