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

            //Debug, extra null checks for merc.  Trying to track down a rare NRE.
            // The shuttle Cargo View check shouldn't be necessary, but just in case.
            //  The view should already be active.  
            //  My guess is that the backpack not being visible is the issue...

            if ( arsenalScreen._shuttleCargoStorageView?.isActiveAndEnabled == true
                || arsenalScreen._merc?.CreatureData?.Inventory?.BackpackStore == null)
            {
                return;
            }

            arsenalScreen._merc.CreatureData.Inventory.BackpackStore.
                SortWithExpandByTypeAndName(Bootstrap._state.Get<SpaceTime>());

            arsenalScreen.RefreshView();
        }
    }
}
