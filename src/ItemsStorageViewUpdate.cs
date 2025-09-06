using MGSC;
using System.Linq;
using UnityEngine;

namespace StorageSort
{
    public class ItemsStorageViewUpdate : MonoBehaviour
    {
        public ItemsStorageView ItemsStorageView { get; set; }

        private static KeyCode SortKey;
        private static KeyCode DropKey;

        static ItemsStorageViewUpdate()
        {
            SortKey = Plugin.Config.SortKey;
            DropKey = Plugin.Config.DropKey;
        }

        public void Update()
        {
            ItemStorage storage = ItemsStorageView?.Storage;

            if (Input.GetKeyDown(SortKey))
            {
                SortItems(storage);
            }
            else if (Input.GetKeyDown(DropKey))
            {
                InventoryScreen screen;

                screen = UI.GetActiveViews().OfType<InventoryScreen>().FirstOrDefault();

                //Mono doesn't like null forgiving operators
                if (screen == null || !screen.isActiveAndEnabled ) return;

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
