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
    [HarmonyPatch(typeof(ScreenWithShipCargo), nameof(ScreenWithShipCargo.Update))]
    public static class ScreenWithShipCargo_Update_Patch
    {
        public static void Prefix(ScreenWithShipCargo __instance)
        {
            if (__instance.isActiveAndEnabled && Input.GetKeyDown(Plugin.Config.SpaceSortKey))
            {
                __instance.SortArsenalButtonOnClick(null, 1);
            }
        }
    }
}
