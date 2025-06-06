[h1]Storage Sort, Drop, Single Drop, Recycle All[/h1]


[h1]Docs[/h1]

Adds a sort, drop all, and recycle all hotkeys to storages.
Adds the context menu command "Drop One".

Default keys: S sorts, D drops all items, and Shift + R recycles all items.
Keys can be configured.  See the Configuration section below.

The drop all key is useful when dropping gas from barrels in one keystroke.
The "Drop One" command is useful when dropping a single item from a stack to keep a door open.  For example, a piece of plastic.

[h1]"Drop One" and Context Menu Hotkeys Mod[/h1]

To add a hotkey to the "Drop One" function in the Context Menu Hotkeys mod, add this to the list of keys in the Context Menu Hokeys config file:
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
[td]The key that sorts the current storage inventory
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
[tr]
[td]RecycleAllKey
[/td]
[td]Shift + R
[/td]
[td]Recycles all items in the container
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
[*]Thanks to Steam user Traveler for the Recycle All suggestion and providing the code.
[/list]

[h1]Change Log[/h1]

[h2]2.2.0[/h2]
[list]
[*]Added "Recycle All" hotkey.
[*]Changed hotkeys to support multiple keys.
[/list]

[h2]2.1.0[/h2]
[list]
[*]Added "Drop One" command.
[/list]

[h2]2.0.1[/h2]
[list]
[*]Fixed mod config using key codes instead of the string version.
[*]Thanks goes to Steam user Traveler for reporting this issue.
[/list]

[h2]2.0.0[/h2]
[list]
[*]Added Drop All key.
[/list]
