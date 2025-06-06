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
        public List<KeyCode> Chord { get; set; } = new List<KeyCode>();

        public KeyChord()
        {
                
        }

        public KeyChord(params KeyCode[] chords)
        {
            Chord = new List<KeyCode>(chords);
        }

        public KeyChord(List<KeyCode> chords)
        {
            Chord = chords;
        }

        /// <summary>
        /// Returns true if the chord is pressed.
        /// </summary>
        /// <returns></returns>
        public bool IsPressed()
        {
            //This is a hack.  Should be a Func or organized better.
            //Works for this mod.  This key is only for the ItemsStorage Screen.

            return ItemsStorageViewUpdate.KeyHandler.KeysArePressed(Chord);
            
        }
    }
}
