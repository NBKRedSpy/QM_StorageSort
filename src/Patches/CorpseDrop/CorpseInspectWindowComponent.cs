using MGSC;
using StorageSort.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
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
                if (!Input.GetKey(Plugin.Config.DropKey)) return;

                DropAllItems();

            }
            catch (Exception ex)
            {

                Plugin.Logger.LogError(ex);
            }

        }

        private void DropAllItems()
        {
            UI.Get<InventoryScreen>().TakeAllFromCorpse();

            //COPY WARNING: InventoryScreen.TakeAllFromCorpse().
            //  This is a copy of the drop logic from that function, minus the inventory add logic.

        }
    }
}
