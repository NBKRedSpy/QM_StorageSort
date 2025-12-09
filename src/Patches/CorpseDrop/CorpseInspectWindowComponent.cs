using MGSC;
using StorageSort.Patches.DropAndSort;
using StorageSort.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

namespace StorageSort.Patches.BackpackSort
{
    /// <summary>
    /// Handles dropping all items from a corpse.  The component is required as
    /// CorpseInspectWindow dowes not have an Update function.
    /// </summary>
    internal class CorpseInspectWindowComponent : UpdateComponent<CorpseInspectWindow>
    {
        public override void Update()
        {
            try
            {
                if (!InputHelper.GetKey(Plugin.Config.DropKey)) return;

                List<BasePickupItem> items =
                    UI.Get<CorpseInspectWindow>().CorpseStorage.CreatureData.Inventory.AllContainers
                        .SelectMany(x => x.Items).ToList();

                ItemsStorageViewUpdate.DropAllItems(items);

            }
            catch (Exception ex)
            {
                Plugin.Logger.LogError(ex);
            }

        }

    }
}
