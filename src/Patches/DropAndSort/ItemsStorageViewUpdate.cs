using MGSC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StorageSort.Patches.DropAndSort
{
    /// <summary>
    /// Handles the in raid "drop all" and sort of storage invnetory key presses.
    /// </summary>
    public class ItemsStorageViewUpdate : MonoBehaviour
    {
        public ItemsStorageView ItemsStorageView { get; set; }

        public void Update()
        {
            ItemStorage storage = ItemsStorageView?.Storage;

            if (!Input.anyKeyDown) return;

            InventoryScreen screen;

            screen = UI.GetActiveViews().OfType<InventoryScreen>().FirstOrDefault();

            //Mono doesn't like null forgiving operators
            if (screen == null || !screen.isActiveAndEnabled) return;

            if (Plugin.Config.IsRaidSortPressed())
            {
                SortItems(storage);
            }
            else if (Input.GetKeyDown(Plugin.Config.DropKey))
            {

                DropAllItems(storage.Items);

                //Sort the results.
                SortItems(storage);

                screen.Hide();
            }
        }

        /// <summary>
        /// Drops all of the items from the specified storage.
        /// </summary>
        /// <param name="storage"></param>
        public static void DropAllItems(List<BasePickupItem> items)
        {
            InventoryScreen screen = UI.Get<InventoryScreen>();

            for (int i = items.Count - 1; i >= 0; i--)
            {
                BasePickupItem item = items[i];

                screen.DragControllerDropOutsideCallback(item);
                screen.DragControllerInteractionCallback(InventoryInteractionType.DropOutside);
                screen.DragControllerRefreshCallback();

            }
        }

        private void SortItems(ItemStorage storage)
        {
            storage.SortWithExpandByTypeAndName(Bootstrap._state.Get<SpaceTime>());
            //Handles the refresh.
            ItemsStorageView.InitContent(storage);
        }
    }
}
