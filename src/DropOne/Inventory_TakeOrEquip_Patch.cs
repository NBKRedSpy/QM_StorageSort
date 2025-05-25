using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StorageSort.DropOne
{
    [HarmonyPatch(typeof(Inventory), nameof(Inventory.TakeOrEquip))]
    internal class Inventory_TakeOrEquip_Patch
    {

        public static bool IsDungeonMode { get; set; }


        public static bool Prefix(BasePickupItem item, ref bool __result)
        {

            //if (!IsDungeonMode || !PreventMove) return true;

            //            if (Plugin.ExcludeItemList.Items.Contains(item.Id))
            //{
            //    __result = false;
            //    return false;
            //}

            return true;
        }
    }
}
