using HarmonyLib;
using MGSC;
using StorageSort.DropOne;
using StorageSort.Mcm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StorageSort
{
    public static class Plugin
    {

        public static ConfigDirectories ConfigDirectories = new ConfigDirectories();

        public static ModConfig Config { get; private set; }

        public static Logger Logger = new Logger();

        private static McmConfiguration McmConfiguration { get; set; }


        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfig(IModContext context)
        {

            Directory.CreateDirectory(ConfigDirectories.ModPersistenceFolder);

            Config = ModConfig.LoadConfig(ConfigDirectories.ConfigPath);

            McmConfiguration = new McmConfiguration(Config);
            McmConfiguration.TryConfigure();

            new Harmony("NBKRedSpy_" + ConfigDirectories.ModAssemblyName).PatchAll();
        }

        [Hook(ModHookType.DungeonStarted)]
        public static void DungeonStarted(IModContext context)
        {
            Inventory_TakeOrEquip_Patch.IsDungeonMode = true;
        }



        [Hook(ModHookType.DungeonFinished)]
        public static void DungeonFinished(IModContext context)
        {
            Inventory_TakeOrEquip_Patch.IsDungeonMode = false;

        }

    }
}
