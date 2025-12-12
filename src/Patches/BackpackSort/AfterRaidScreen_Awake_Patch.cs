using HarmonyLib;
using MGSC;
using System;
using UnityEngine;

namespace StorageSort.Patches.BackpackSort
{
    /// <summary>
    /// Attach the After Raid Screen component that handles the backpack sorting.
    /// Required as there is no Update on the AfterRaidScreen.
    /// Even though it looks identical.
    /// </summary>
    [HarmonyPatch(typeof(AfterRaidScreen), nameof(AfterRaidScreen.Awake))]
    public class AfterRaidScreen_Awake_Patch
    {
        public static void Postfix(AfterRaidScreen __instance)
        {
            try
            {
                //Tries to add if it isn't already attached.
                AfterRaidScreenBackpackComponent.CreateComponent<AfterRaidScreenBackpackComponent>(__instance);
            }
            catch (Exception ex)
            {
                Plugin.Logger.LogError(ex);
            }
        }
    }
}
