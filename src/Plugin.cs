using HarmonyLib;
using MGSC;
using StorageSort.DropOne;
using StorageSort.Mcm;
using StorageSort_Bootstrap;
using System.IO;

namespace StorageSort
{
    public class Plugin :BootstrapMod
    {

        public static ConfigDirectories ConfigDirectories = new ConfigDirectories();

        public static ModConfig Config { get; private set; }

        public static Logger Logger = new Logger();

        private static McmConfiguration McmConfiguration { get; set; }

        public Plugin(HookEvents hookEvents, bool isBeta) : base(hookEvents, isBeta)
        {

            HookEvents.DungeonStarted += DungeonStarted;
            HookEvents.DungeonFinished += DungeonFinished;

            Directory.CreateDirectory(ConfigDirectories.ModPersistenceFolder);

            Config = new ModConfig(ConfigDirectories.ConfigPath).LoadConfig();

            McmConfiguration = new McmConfiguration(Config);
            McmConfiguration.TryConfigure();

            new Harmony("NBKRedSpy_" + ConfigDirectories.ModAssemblyName).PatchAll();
        }

        public static void DungeonStarted(IModContext context)
        {
            Inventory_TakeOrEquip_Patch.IsDungeonMode = true;
        }

        public static void DungeonFinished(IModContext context)
        {
            Inventory_TakeOrEquip_Patch.IsDungeonMode = false;

        }

    }
}
