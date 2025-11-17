using HarmonyLib;
using MGSC;
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

            Directory.CreateDirectory(ConfigDirectories.ModPersistenceFolder);

            Config = new ModConfig(ConfigDirectories.ConfigPath).LoadConfig();

            McmConfiguration = new McmConfiguration(Config);
            McmConfiguration.TryConfigure();

            new Harmony("NBKRedSpy_" + ConfigDirectories.ModAssemblyName).PatchAll();
        }
    }
}
