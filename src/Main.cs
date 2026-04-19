using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MGSC;
using Newtonsoft.Json;
using UnityEngine;

namespace StorageSort_Bootstrap
{
    public static class Main
    {

        public static Logger Log = new Logger();
        public static HookEvents HookEvents { get; set; } = new HookEvents();
        public static BootstrapMod BootstrapMod { get; set; }
        
        [Hook(ModHookType.BeforeBootstrap)]
        public static void Init(IModContext context)
        {

            try
            {

                string modDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                bool isBeta;
                if (VersionCheck.DisableModCheck(modDir, out isBeta)) return;

                Assembly modAssembly = Assembly.LoadFile(Path.Combine(modDir, isBeta ? "beta" : "stable", "StorageSort.dll"));

                //Using reflection to prevent cyclic dependency
                Type bootstrapModType = modAssembly.GetTypes()
                    .Where(x => x.IsSubclassOf(typeof(BootstrapMod)))
                    .FirstOrDefault();

                if (bootstrapModType == null)
                {
                    Log.LogError("Could not find the BootstrapMod entry in the assembly.");
                    return;
                }

                BootstrapMod = (BootstrapMod)Activator.CreateInstance(bootstrapModType, new object[] { HookEvents, isBeta });

            }
            catch (Exception ex)
            {
                Log.LogError(ex, "Error loading Map Markers mod.");
            }
        }

        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfigsLoadedCallback(IModContext context) => HookEvents?.AfterConfigsLoaded?.Invoke(context);

        [Hook(ModHookType.DungeonStarted)]
        public static void DungeonStartedCallback(IModContext context) => HookEvents?.DungeonStarted?.Invoke(context);
        
        [Hook(ModHookType.DungeonFinished)]
        public static void DungeonFinishedCallback(IModContext context) => HookEvents?.DungeonFinished?.Invoke(context);
    }
}
