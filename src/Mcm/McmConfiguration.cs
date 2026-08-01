using ModConfigMenu;
using ModConfigMenu.Contracts;
using ModConfigMenu.Objects;
using System.Collections.Generic;
using UnityEngine;

namespace StorageSort.Mcm
{
    internal class McmConfiguration : McmConfigurationBase
    {

        public McmConfiguration(ModConfig config) : base (config) { }

        public override void Configure()
        {
            ModConfigMenuAPI.RegisterModConfig("Storage Sort", new List<IConfigValue>()
            {
                new ConfigValue("__CorpseWarning", $"{WarningColorElement}This mod does not target corpses, only containers</color>", "Corpse Note"),
                CreateEnumDropdown<KeyCode>(nameof(ModConfig.SortKey), "Sort Key when a storage container is open.", "Storage Sort Key", sort: true),
                CreateEnumDropdown<KeyCode>(nameof(ModConfig.BackpackSortModifierKey), "The key to hold down while pressing the 'Sort Key' to sort the player's backpack instead of a container.\nSet to None to disable backpack sort.", "Backpack Sort Modifier Key", sort: true),
                CreateEnumDropdown<KeyCode>(nameof(ModConfig.SpaceSortKey), "The key to sort the ship's inventory when on the loading out screen.", "Ship Sort Key", sort: true),
                CreateEnumDropdown<KeyCode>(nameof(ModConfig.DropKey), "Key to drop all items from a container", "Drop All Key",sort: true),
                new ConfigValue("__ContextNote", 
                    """
                    The 'Drop One' context menu command can be mapped in the 'Hotkeys for Context Menus'
                    mod using 620000 for the Command.  Ex: \"Command\": 620000"
                    """, "Note")
            }, OnSave);
        }
    }
}
