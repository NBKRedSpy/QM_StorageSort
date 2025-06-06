using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StorageSort
{


    /// <summary>
    /// A input helper that returns true if one or more key chords are being pressed.
    /// </summary>
    public class KeyChord
    {
        public HashSet<KeyCode> Chord { get; set; } = new HashSet<KeyCode>();

        #region KeyCode Data
        private static HashSet<KeyCode> ModifierKeys = new HashSet<KeyCode>()
        {
            KeyCode.LeftShift,
            KeyCode.RightShift,
            KeyCode.LeftControl,
            KeyCode.RightControl,
            KeyCode.LeftAlt,
            KeyCode.RightAlt,
            KeyCode.LeftWindows,
            KeyCode.RightWindows,
            KeyCode.LeftApple,
            KeyCode.RightApple
        };

        /// <summary>
        /// The list of keys to check for KeyDown events.  Does not include the modifier keys.
        /// </summary>
        private static List<KeyCode> AllNonModifierKeys = new List<KeyCode>()
        {
            KeyCode.A,
            KeyCode.B,
            KeyCode.C,
            KeyCode.D,
            KeyCode.E,
            KeyCode.F,
            KeyCode.G,
            KeyCode.H,
            KeyCode.I,
            KeyCode.J,
            KeyCode.K,
            KeyCode.L,
            KeyCode.M,
            KeyCode.N,
            KeyCode.O,
            KeyCode.P,
            KeyCode.Q,
            KeyCode.R,
            KeyCode.S,
            KeyCode.T,
            KeyCode.U,
            KeyCode.V,
            KeyCode.W,
            KeyCode.X,
            KeyCode.Y,
            KeyCode.Z,
            KeyCode.Alpha0,
            KeyCode.Alpha1,
            KeyCode.Alpha2,
            KeyCode.Alpha3,
            KeyCode.Alpha4,
            KeyCode.Alpha5,
            KeyCode.Alpha6,
            KeyCode.Alpha7,
            KeyCode.Alpha8,
            KeyCode.Alpha9,
            KeyCode.F1,
            KeyCode.F2,
            KeyCode.F3,
            KeyCode.F4,
            KeyCode.F5,
            KeyCode.F6,
            KeyCode.F7,
            KeyCode.F8,
            KeyCode.F9,
            KeyCode.F10,
            KeyCode.F11,
            KeyCode.F12,
            KeyCode.F13,
            KeyCode.F14,
            KeyCode.F15,
            KeyCode.Space,
            KeyCode.Mouse0,
            KeyCode.Mouse1,
            KeyCode.Mouse2,
            KeyCode.Mouse3,
            KeyCode.Mouse4,
            KeyCode.Mouse5,
            KeyCode.Mouse6,
            KeyCode.Escape,
            KeyCode.KeypadEnter,
            KeyCode.LeftArrow,
            KeyCode.RightArrow,
            KeyCode.UpArrow,
            KeyCode.DownArrow,
            KeyCode.Backspace,
            KeyCode.Tab,
            KeyCode.Return,
            KeyCode.CapsLock,
            KeyCode.Escape,
            KeyCode.Quote,
            KeyCode.Comma,
            KeyCode.Minus,
            KeyCode.Period,
            KeyCode.Slash,
            KeyCode.Semicolon,
            KeyCode.Equals,
            KeyCode.LeftBracket,
            KeyCode.Backslash,
            KeyCode.RightBracket,
            KeyCode.BackQuote,
            KeyCode.Delete,
            KeyCode.Keypad0,
            KeyCode.Keypad1,
            KeyCode.Keypad2,
            KeyCode.Keypad3,
            KeyCode.Keypad4,
            KeyCode.Keypad5,
            KeyCode.Keypad6,
            KeyCode.Keypad7,
            KeyCode.Keypad8,
            KeyCode.Keypad9,
            KeyCode.KeypadPeriod,
            KeyCode.KeypadDivide,
            KeyCode.KeypadMultiply,
            KeyCode.KeypadMinus,
            KeyCode.KeypadPlus,
            KeyCode.KeypadEquals,
            KeyCode.Insert,
            KeyCode.Home,
            KeyCode.End,
            KeyCode.PageUp,
            KeyCode.PageDown,
            KeyCode.Mouse0,
            KeyCode.Mouse1,
            KeyCode.Mouse2,
            KeyCode.Mouse3,
            KeyCode.Mouse4,
            KeyCode.Mouse5,
            KeyCode.Mouse6,
            KeyCode.BackQuote,
            KeyCode.Backslash,
            KeyCode.Backspace,
            KeyCode.CapsLock,
            KeyCode.Comma,
            KeyCode.Delete,
            KeyCode.DownArrow,
            KeyCode.End,
            KeyCode.Equals,
            KeyCode.Escape,
            KeyCode.Home,
            KeyCode.Insert,
            KeyCode.Keypad0,
            KeyCode.Keypad1,
            KeyCode.Keypad2,
            KeyCode.Keypad3,
            KeyCode.Keypad4,
            KeyCode.Keypad5,
            KeyCode.Keypad6,
            KeyCode.Keypad7,
            KeyCode.Keypad8,
            KeyCode.Keypad9,
            KeyCode.KeypadDivide,
            KeyCode.KeypadEnter,
            KeyCode.KeypadEquals,
            KeyCode.KeypadMinus,
            KeyCode.KeypadMultiply,
            KeyCode.KeypadPeriod,
            KeyCode.KeypadPlus,
            KeyCode.LeftArrow,
            KeyCode.LeftBracket,
            KeyCode.Minus,
            KeyCode.PageDown,
            KeyCode.PageUp,
            KeyCode.Period,
            KeyCode.Quote,
            KeyCode.Return,
            KeyCode.RightArrow,
            KeyCode.RightBracket,
            KeyCode.Semicolon,
            KeyCode.Slash,
            KeyCode.Space,
            KeyCode.Tab,
            KeyCode.UpArrow,
        };

        #endregion

        public KeyChord()
        {
                
        }

        public KeyChord(params KeyCode[] chords)
        {
            Chord = new HashSet<KeyCode>(chords);
        }

        public KeyChord(HashSet<KeyCode> chords)
        {
            Chord = chords;
        }

        /// <summary>
        /// Returns true if the target keys are down
        /// </summary>
        /// <returns></returns>
        public bool IsPressed()
        {

            if (Chord.Count == 0) return false;

            //Pre check the target keys are set to avoid the full loop
            foreach (KeyCode key in Chord)
            {
                if(!KeyIsDown(key)) return false; 
            }

            // ---- Check if any key not in the chord is set. 
            // Prevents Shift + R and Ctrl + shift + R both firing the same chord.
            // There is not an easier way to do this with the legacy input system.
            // Could possibly copy over the new input system, but this should be fine.

            // Do modifier keys first since these are the most likely to be down
            foreach (KeyCode key in ModifierKeys)
            {
                if (Chord.Contains(key)) continue;

                if (Input.GetKey(key))
                {
                    return false;
                }
            }

            //Check non modifier keys.  The list is ordered by most likely keys pressed first.
            foreach (KeyCode key in AllNonModifierKeys)
            {
                if (Chord.Contains(key)) continue;
                if (Input.GetKeyDown(key)) return false;
            }

            return true;
        }

        private bool KeyIsDown(KeyCode key)
        {
            if (ModifierKeys.Contains(key))
            {
                if (!Input.GetKey(key)) return false;
            }
            else
            {
                if (!Input.GetKeyDown(key)) return false;
            }

            return true;
        }

    }

}
