﻿using HarmonyLib;
using MGSC;
using ModConfigMenu;
using ModConfigMenu.Objects;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;

namespace StorageSort.Mcm
{
    /// <summary>
    /// </summary>
    /// <remarks>This is a prototype.  It has too many direct use external requirements.</remarks>
    /// <param name="config"></param>
    internal abstract class McmConfigurationBase(ModConfig config)
    {

        public ModConfig Config { get; set; } = config;

        /// <summary>
        /// Used to set the defaults established by the ModConfig class.
        /// </summary>
        private ModConfig Defaults { get; set; } = new ModConfig();

        /// <summary>
        /// Used to make the keys for read only entries unique.
        /// </summary>
        private static int UniqueId = 0;

        /// <summary>
        /// Attempts to configure the MCM, but logs an error and continues if it fails.
        /// </summary>
        public bool TryConfigure()
        {
            try
            {
                Configure();
                return true;
            }
            catch (FileNotFoundException)
            {
                Plugin.Logger.Log("Bypassing MCM. The 'Mod Configuration Menu' mod is not loaded. ");
            }
            catch (Exception ex)
            {
                Plugin.Logger.LogError(ex, "An error occurred when configuring MCM");
            }

            return false;
        }

        
        /// <summary>
        /// The ModConfig specific configuration.  Use the Create* and OnSave helper functions.
        /// </summary>
        public abstract void Configure();


        protected ConfigValue CreateRestartMessage()
        {
            return new ConfigValue("__Restart", "The game must be restarted for any changes to take effect.", "Restart");

        }

        /// <summary>
        /// Creates a setting that is only available in the config file due to lack of MCM support.
        /// Creates a unique ID for the key to avoid the Save from picking it up.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        protected ConfigValue CreateReadOnly(string propertyName, string header = "Only available in config file")
        {
            int key = UniqueId++;



            object value = AccessTools.Property(typeof(ModConfig), propertyName)?.GetValue(Config);

            if(value == null)
            {
                //Try field
                value = AccessTools.Field(typeof(ModConfig), propertyName)?.GetValue(Config);
            }

            string formattedValue;

            if (value == null)
            {
                value = "Null";
            }
            if (value is IEnumerable enumList)
            {
                List<string> list = new();

                foreach (var item in enumList)
                {
                    list.Add(item.ToString());
                }

                formattedValue = string.Join(",", list);
            }
            else
            {
                formattedValue = value.ToString();
            }

            string formattedPropertyName = FormatUpperCaseSpaces(propertyName);

            return new ConfigValue(key.ToString(), $@"{formattedPropertyName}: <color=#FFFEC1>{formattedValue}</color>", header);

        }

        /// <summary>
        /// Formats a string with no spaces to having spaces before each uppercase letter.
        /// Used to make a property name easier to read.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private static string FormatUpperCaseSpaces(string propertyName)
        {
            //Since the UI uppercases the text, add spaces to make it easier to read.
            Regex regex = new Regex(@"([A-Z0-9])");
            string formattedPropertyName = regex.Replace(propertyName.ToString(), " $1").TrimStart();
            return formattedPropertyName;
        }

        protected ConfigValue CreateConfigProperty<T>(string propertyName,
            string tooltip, string label, T min, T max, string header = "General") where T: struct
        {
            T defaultValue = (T)AccessTools.Property(typeof(ModConfig), propertyName).GetValue(Defaults);
            T propertyValue = (T)AccessTools.Property(typeof(ModConfig), propertyName).GetValue(Config);

            switch (typeof(T))
            {
                case Type floatType when floatType == typeof(float):

                    return new ConfigValue(propertyName, propertyValue, header, defaultValue, 
                        tooltip, label, Convert.ToSingle(min), Convert.ToSingle(max));
                case Type intType when intType == typeof(int):
                    return new ConfigValue(propertyName, propertyValue, header, defaultValue,
                        tooltip, label, Convert.ToInt32(min), Convert.ToInt32(max));
                default:
                    throw new ApplicationException($"Unexpected numeric type '{typeof(T).Name}'");
            }
        }

        /// <summary>
        /// Creates a configuration value.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="tooltip"></param>
        /// <param name="label">If not set, will use the property name, adding spaced before each capital letter.</param>
        /// <param name="header"></param>
        /// <returns></returns>
        protected ConfigValue CreateConfigProperty(string propertyName,
            string tooltip, string label = "", string header = "General")
        {
            object defaultValue = AccessTools.Property(typeof(ModConfig), propertyName).GetValue(Defaults);
            object propertyValue = AccessTools.Property(typeof(ModConfig), propertyName).GetValue(Config);

            string formattedLabel = label == "" ? FormatUpperCaseSpaces(propertyName) : label;

            return new ConfigValue(propertyName, propertyValue, header, defaultValue, tooltip, formattedLabel);
        }

        /// <summary>
        /// Sets the ModConfig's property that matches the ConfigValue key.
        /// Returns false if the property could not be found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        protected bool SetModConfigValue(string key, object value)
        {
            MethodInfo propertyMethod = AccessTools.Property(typeof(ModConfig), key)?.GetSetMethod();


            //Try property
            if (propertyMethod != null)
            {
                propertyMethod.Invoke(Config, new object[] { value });
                return true;
            }

            //Try field.
            if (propertyMethod == null)
            {
                //Try field

                var field = AccessTools.Field(typeof(ModConfig), key);
                if(field == null)
                {
                    return false;

                }

                field.SetValue(Config, value);
                return true;
            }

            return false;
        }

        protected virtual bool OnSave(Dictionary<string, object> currentConfig, out string feedbackMessage)
        {
            feedbackMessage = "";

            foreach (var entry in currentConfig)
            {
                SetModConfigValue(entry.Key, entry.Value);
            }

            Config.Save();

            return true;
        }
    }
}
