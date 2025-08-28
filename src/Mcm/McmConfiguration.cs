using ModConfigMenu;
using ModConfigMenu.Objects;
using System.Collections.Generic;

namespace StorageSort.Mcm
{
    internal class McmConfiguration : McmConfigurationBase
    {

        public McmConfiguration(ModConfig config) : base (config) { }

        public override void Configure()
        {
            ModConfig defaults = new ModConfig();

            ModConfigMenuAPI.RegisterModConfig("Storage Sort", new List<ConfigValue>()
            {
                CreateReadOnly(nameof(ModConfig.SortKey)),
                CreateReadOnly(nameof(ModConfig.DropKey)),
                new ConfigValue("__ContextNote", "The 'Drop One' context menu command can be mapped in the 'Hotkeys for Context Menus' " + 
                    "mod using 620000 for the Command.  Ex: \"Command\": 620000", "Note")
            }, OnSave);
        }
    }
}
