using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGSC;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using StorageSort.Mcm;
using UnityEngine;

namespace StorageSort
{
    public class ModConfig : PersistentConfig<ModConfig>
    {
        public ModConfig() { }
        public ModConfig(string configPath) : base(configPath)
        {
        }

        public KeyCode SortKey { get; set; } = KeyCode.S;


        /// <summary>
        /// Hold this key while pressing the SortKey to sort the backpack when in a raid.
        /// Set to Keycode.None to use the Sortkey alone.
        /// </summary>
        public KeyCode BackpackSortModifierKey { get; set; } = KeyCode.None;

        public KeyCode SpaceSortKey { get; set; } = KeyCode.S;

        public KeyCode DropKey { get; set; } = KeyCode.D;


        /// <summary>
        /// True if the backpack sort key combination is pressed, and not disabled.
        /// </summary>
        /// <returns></returns>
        public bool IsBackpackSortPressed()
        {
            return Input.GetKeyDown(SortKey) && (BackpackSortModifierKey == KeyCode.None ||
                Input.GetKey(BackpackSortModifierKey));
        }

        /// <summary>
        /// Returns true if the raid sort key is pressed (and not the backpack sort).
        /// </summary>
        /// <returns></returns>
        public bool IsRaidSortPressed()
        {
            return !IsBackpackSortPressed() && Input.GetKeyDown(SortKey);
            
        }   
    }
}
