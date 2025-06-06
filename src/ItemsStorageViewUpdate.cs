using MGSC;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.Device;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

namespace StorageSort
{
    public class ItemsStorageViewUpdate : MonoBehaviour
    {
        public ItemsStorageView ItemsStorageView { get; set; }

        private static KeyChord SortKey;
        private static KeyChord DropKey;
        private static KeyChord RecycleAllKey;

        static ItemsStorageViewUpdate()
        {
            SortKey = Plugin.Config.SortKey;
            DropKey = Plugin.Config.DropKey;
            RecycleAllKey = Plugin.Config.RecycleAllKey;
        }

        public void Update()
        {
            ItemStorage storage = ItemsStorageView?.Storage;
            if (storage?.Empty ?? true) return;

            if (SortKey.IsPressed())
            {
                SortItems(storage);
            }
            else if (DropKey.IsPressed())
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
            else if (RecycleAllKey.IsPressed())
            {
                //WARNING - COPY:  This is effectively a copy of the MGSC.CorpseInspectWindow.DisassemblyAllItems() logic.
                InventoryScreen screen = UI.GetActiveViews().OfType<InventoryScreen>().FirstOrDefault();

                if (screen == null || !screen.isActiveAndEnabled) return;  //Mono doesn't like null forgiving operators

                List<BasePickupItem> list = new List<BasePickupItem>();
                list.AddRange(storage.Items);

                bool weaponUnloaded = false;
                bool itemDisassembled = false;

                for (int i = 0; i < list.Count; i++)
                {
                    if (ItemInteractionSystem.CanDisassemble(list[i]))
                    {
                        screen.DisassembleItem(list[i], -1, true, false);
                        weaponUnloaded = screen.TryUnloadWeapon(list[i], false);
                        itemDisassembled = true;
                    }
                }
                
                //Play a single sound based on what occurred.
                if (itemDisassembled)
                {
                    AudioClip clip = (weaponUnloaded? SingletonMonoBehaviour<SoundsStorage>.Instance.AmmoReceived : SingletonMonoBehaviour<SoundsStorage>.Instance.EmptyAttack);
                    SingletonMonoBehaviour<SoundController>.Instance.PlayUiSound(clip);

                    var creatures = Plugin.State.Get<Creatures>();

                    PlayerInteractionSystem.EndPlayerTurn(creatures, PlayerEndTurnContext.InventoryInteraction);
                    creatures.Player.CreatureData.EffectsController.PropagateAction(PlayerActionHappened.HandAction);
                }

                //Sort the results.
                SortItems(storage);
            }
        }


        #region Key Event Hack

        //TODO:  This needs to be put into it's own class.

        internal static OnGuiKeyHandler KeyHandler = new OnGuiKeyHandler();

        internal void OnDisable()
        {
            KeyHandler.Clear();
        }

        internal void OnDestroy()
        {
            KeyHandler.Clear();
        }

        /// <summary>
        /// Determines if the keys are being pressed.
        /// </summary>
        internal void OnGUI()
        {
            KeyHandler.ProcessOnGuiLoop();
        }

        #endregion



        private void SortItems(ItemStorage storage)
        {
            storage.SortWithExpandByTypeAndName(Bootstrap._state.Get<SpaceTime>());
            //Handles the refresh.
            ItemsStorageView.InitContent(storage);
        }
    }
}
