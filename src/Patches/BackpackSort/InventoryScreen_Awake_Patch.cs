using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StorageSort.Patches.BackpackSort
{
    /// <summary>
    /// Attach the Backpack sort component as the InventoryScreen does not have an Update function.
    /// </summary>
    [HarmonyPatch(typeof(InventoryScreen), nameof(InventoryScreen.Awake))]
    public static class InventoryScreen_Awake_Patch
    {
        public static void Postfix(InventoryScreen __instance)
        {
            //Tries to add if it isn't already attached.
            BackpackSortComponent.CreateComponent<BackpackSortComponent>(__instance);   
        }

    }
}
