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

        [JsonConverter(typeof(StringEnumConverter))]    
        public KeyCode SortKey { get; set; } = KeyCode.S;

        [JsonConverter(typeof(StringEnumConverter))]
        public KeyCode SpaceSortKey { get; set; } = KeyCode.S;


        [JsonConverter(typeof(StringEnumConverter))]
        public KeyCode DropKey { get; set; } = KeyCode.D;
    }
}
