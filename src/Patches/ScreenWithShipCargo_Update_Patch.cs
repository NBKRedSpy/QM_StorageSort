using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StorageSort.Patches
{
    /// <summary>
    /// Adds a hotkey to sort the ship cargo inventory.
    /// </summary>
    [HarmonyPatch(typeof(ScreenWithShipCargo), nameof(ScreenWithShipCargo.Update))]
    public static class ScreenWithShipCargo_Update_Patch
    {
        public static void Prefix(ScreenWithShipCargo __instance)
        {
            if (!InputHelper.GetKeyDown(Plugin.Config.SpaceSortKey)) return;

            //-- Inventory sort button.
            __instance.SortArsenalButtonOnClick(null, 1);

            //-- Backpack sort
            ArsenalScreen arsenalScreen = __instance as ArsenalScreen;

            if (arsenalScreen == null || arsenalScreen._merc == null) return;

            arsenalScreen._merc.CreatureData.Inventory.BackpackStore.
                SortWithExpandByTypeAndName(Bootstrap._state.Get<SpaceTime>());

            arsenalScreen.RefreshView();
        }
    }
}
