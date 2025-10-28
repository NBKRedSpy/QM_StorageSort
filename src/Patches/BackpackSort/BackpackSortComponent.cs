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
    /// Handles sorting the player's backpack.  Is attached to the ItemStorageView
    /// </summary>
    internal class BackpackSortComponent : UpdateComponent<InventoryScreen>
    {
        public override void Update()
        {
            try
            {
                if (!Plugin.Config.IsBackpackSortPressed()) return;

                Component?.ActiveStorage.SortWithExpandByTypeAndName(Bootstrap._state.Get<SpaceTime>());
                Component.RefreshItemsList();

                AudioClip clip = SingletonMonoBehaviour<SoundsStorage>.Instance.TakeItem;
                SingletonMonoBehaviour<SoundController>.Instance.PlayUiSound(clip, true);


            }
            catch (Exception ex)
            {

                Plugin.Logger.LogError(ex);
            }

        }
    }
}
