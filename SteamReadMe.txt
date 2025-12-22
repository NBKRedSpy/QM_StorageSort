[h1]Storage Sort, Drop, and Single Drop[/h1]


[h1]Docs[/h1]

Features:
[list]
[*]Adds sort the many of the inventory screens in raid and in space.  Defaults to S.
[*]Adds a Drop All hotkey to containers and corpses.  Defaults to D.
[*]Adds the context menu command "Drop One".
[/list]

Each feature can be disabled in the configuration by setting the key to None.

The drop all key is useful when dropping gas from barrels in one keystroke.

The "Drop One" command is useful when dropping a single item from a stack to keep a door open.  For example, a piece of plastic.

The keys can be configured using the Mods button on the main screen or directly in the config file.

[h1]"Drop One" and Context Menu Hotkeys Mod[/h1]

To add a hotkey to the "Drop One" function in the Context Menu Hotkeys mod,

Add this to the list of keys in the Context Menu Hokeys config file:
[code]
    {
      "Key": "F",
      "Command": 620000
    },

[/code]

The above will add the key F as the hotkey when the context menu is open.

[h1]Configuration[/h1]

The configuration file will be created on the first game run and can be found at [i]%AppData%\..\LocalLow\Magnum Scriptum Ltd\Quasimorph_ModConfigs\StorageSort\config.json[/i].
[table]
[tr]
[td]Name
[/td]
[td]Default
[/td]
[td]Description
[/td]
[/tr]
[tr]
[td]SortKey
[/td]
[td]S
[/td]
[td]The key that sorts the current storage inventory when in a raid.
[/td]
[/tr]
[tr]
[td]BackpackSortModifierKey
[/td]
[td]None
[/td]
[td]The key to hold down while pressing the 'Sort Key' to sort the player's backpack instead of a container. Set to None to not require a modifier key. This currently only works when in a raid.
[/td]
[/tr]
[tr]
[td]SpaceSortKey
[/td]
[td]S
[/td]
[td]The key that sorts the current storage inventory when in space.
[/td]
[/tr]
[tr]
[td]DropKey
[/td]
[td]D
[/td]
[td]Drops all items in a container.
[/td]
[/tr]
[/table]

[h2]Key List[/h2]

The list of valid keyboard keys can be found at the bottom of https://docs.unity3d.com/ScriptReference/KeyCode.html
Beware that numbers 0-9 are Alpha0 - Alpha9.  Most of the other keys are as expected such as X for X.
Use "None" to not bind the key.

[h1]Support[/h1]

If you enjoy my mods and want to buy me a coffee, check out my [url=https://ko-fi.com/nbkredspy71915]Ko-Fi[/url] page.
Thanks!

[h1]Source Code[/h1]

Source code is available on GitHub at https://github.com/NBKRedSpy/QM_StorageSort

[h1]Credits[/h1]
[list]
[*]Special thanks to Crynano for his excellent Mod Configuration Menu.
[/list]

[h1]Change Log[/h1]

[h2]3.5.1[/h2]
[list]
[*]Fix for loadout screen sometimes losing inventory in the backpack.  Extra checking to ensure the backpack is not sorted when on the loadout screen.
[/list]

[h2]3.5.0[/h2]
[list]
[*]Added backpack sort when in space.
[/list]

[h2]3.4.0[/h2]
[list]
[*]Added "drop all" to corpse items.
[*]Changed player backpack sort to not require modifier key by default.
[*]Fix for keys conflicting with open context menu.
[/list]

[h2]3.3.0[/h2]
[list]
[*]Fixed Drop One command not using an AP like what the game's Drop command does.
[/list]

[h2]3.2.0[/h2]
[list]
[*]0.9.7+ Only
[*]Added ability to sort the player's backpack when in raid.
[/list]

[h2]3.1.0[/h2]
[list]
[*]0.9.7+ Only
[*]Added MCM support for key binding.
[*]Fix for sort key invoked while in space.  Missed in previous update.
[*]Internal - Upgraded MCM configuration and all related requirements to the latest versions.
[/list]

[h2]3.0.1[/h2]
[list]
[*]0.9.7+ Only
[*]Fix for sort key invoking when not focused.
[/list]

[h2]3.0.0[/h2]
[list]
[*]Added space cargo screen sort.  This functionality was previously available via the Sort To Tabs mod; However, the game now has a cargo distribution ability and that mod has been decommissioned.
[/list]
