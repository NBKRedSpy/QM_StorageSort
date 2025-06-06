using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StorageSort
{
    /// <summary>
    /// Keeps track of which keys are currently pressed.
    /// The caller must call Clear() if the GameObject is disabled or destroyed.
    /// </summary>
    internal class OnGuiKeyHandler
    {
        /// <summary>
        /// The keys that are currently being pressed.
        /// </summary>
        private static HashSet<KeyCode> CurrentlyPressedKeys = new HashSet<KeyCode>();


        /// <summary>
        /// Processes key events that are available in the OnGUI function
        /// Must be called in a MonoBehaviour's OnGUI function.
        /// </summary>
        public void ProcessOnGuiLoop()
        {
            if (!Event.current.isKey || Event.current.keyCode == KeyCode.None) return;

            if (Event.current.type == EventType.KeyDown)
            {
                CurrentlyPressedKeys.Add(Event.current.keyCode);
            }
            else if (Event.current.type == EventType.KeyUp)
            {
                CurrentlyPressedKeys.Remove(Event.current.keyCode);
            }
        }

        public int PressedKeyCount => CurrentlyPressedKeys.Count;


        public bool KeysArePressed(List<KeyCode> keys)
        {
            if (PressedKeyCount != keys.Count || keys.Count == 0) return false;

            foreach (KeyCode key in keys)
            {
                if (!CurrentlyPressedKeys.Contains(key))
                {
                    return false;
                }
            }

            return true;

        }
        /// <summary>
        /// Resets the internal key list.
        /// This must be called in the MonoBehaviour's OnDisable and OnDestroy.
        /// </summary>
        /// 
        public void Clear()
        {
            CurrentlyPressedKeys.Clear();
        }

    }
}
