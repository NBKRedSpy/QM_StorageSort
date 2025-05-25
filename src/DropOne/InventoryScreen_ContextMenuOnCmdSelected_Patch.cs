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
    //Executes the custom commands from the context menu.
    [HarmonyPatch(typeof(InventoryScreen), nameof(InventoryScreen.ContextMenuOnCmdSelected))]
    public static class InventoryScreen_ContextMenuOnCmdSelected_Patch
    {
        public static void Prefix(InventoryScreen __instance, ref int bindValue)
        {
            //The original function passes through if no command matches.  
            //  so no need for this patch to short circuit.

            //If the command is disabled, it just won't be shown.  No need to check for dungeon mode.
            if ( (ContextMenuCommand) bindValue == (ContextMenuCommand)InventoryScreen_DragControllerShowContextMenuCallback_Patch.DropOneCommand)
            {

                BasePickupItem item = __instance._contextMenuItemSlot.Item;

                if(item.StackCount == 1)
                {
                    //Change to use the game's drop command instead.
                    bindValue = (int)ContextMenuCommand.Drop;
                    return;
                }

                //WARNING - COPY:  This is a copy of the function MGSC.InventoryScreen.ContextMenuOnSplitStackConfirmed(int, int).
                //The only difference is that it does not try to put the split item into inventory, but instead 
                // always drops it on the ground.

                //Split to one item and drop it.
                BasePickupItem basePickupItem = SingletonMonoBehaviour<ItemFactory>.Instance.CreateForInventory(item.Id);
                item.StackCount -= 1;
                basePickupItem.StackCount = 1;
                basePickupItem.ExaminedItem = false;
                basePickupItem.CopyExpireTime(item);
                ItemInteractionSystem.TrySplitUsable(item, basePickupItem);

                __instance._itemsOnFloor.GetOrCreate(__instance._creatures.Player.CreatureData.Position).Storage
                    .TryPutItem(basePickupItem, CellPosition.Zero);

                __instance.RefreshItemsList();
            }
        }
    }
}