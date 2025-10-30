using MGSC;
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

                for (int i = storage.Items.Count - 1; i >= 0; i--)
                {
                    BasePickupItem item = storage.Items[i];

                    screen.DragControllerDropOutsideCallback(item);
                    screen.DragControllerInteractionCallback(InventoryInteractionType.DropOutside);
                    screen.DragControllerRefreshCallback();

                }

                //Sort the results.
                SortItems(storage);

                screen.Hide();
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
