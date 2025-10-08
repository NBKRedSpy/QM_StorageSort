using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGSC;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace StorageSort
{
    public class ModConfig
    {
        [JsonConverter(typeof(StringEnumConverter))]    
        public KeyCode SortKey = KeyCode.S;

        [JsonConverter(typeof(StringEnumConverter))]
        public KeyCode SpaceSortKey = KeyCode.S;


        [JsonConverter(typeof(StringEnumConverter))]
        public KeyCode DropKey = KeyCode.D;

        [JsonIgnore]
        private static JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
        };


        public static ModConfig LoadConfig(string configPath)
        {
            ModConfig config;


            if (File.Exists(configPath))
            {
                try
                {
                    string sourceJson = File.ReadAllText(configPath);

                    config = JsonConvert.DeserializeObject<ModConfig>(sourceJson, SerializerSettings);

                    //Add any new elements that have been added since the last mod version the user had.
                    string upgradeConfig = JsonConvert.SerializeObject(config, SerializerSettings);

                    if (upgradeConfig != sourceJson)
                    {
                        Plugin.Logger.Log("Updating config with missing elements");
                        //re-write
                        File.WriteAllText(configPath, upgradeConfig);
                    }


                    return config;
                }
                catch (Exception ex)
                {
                    Plugin.Logger.LogError(ex, "Error parsing configuration.  Ignoring config file and using defaults");

                    //Not overwriting in case the user just made a typo.
                    config = new ModConfig();
                    return config;
                }
            }
            else
            {
                config = new ModConfig();
                config.Save();                
                return config;
            }
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(this, SerializerSettings);
            File.WriteAllText(Plugin.ConfigDirectories.ConfigPath, json);
        }


    }
}
