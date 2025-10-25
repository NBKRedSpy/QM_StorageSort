[h1]Storage Sort, Drop, and Single Drop[/h1]


[h1]Important Notes for Opt In Beta[/h1]

For users that are running the opt in beta, please see the documentation [url=https://github.com/NBKRedSpy/QM_StorageSort/blob/beta/README.md]here[/url] instead.

[h1]Docs[/h1]

Sorts or drops all items in a container.
By default S sorts and D drops all items.
Adds the context menu command "Drop One".

The drop key is useful when dropping gas from barrels in one keystroke.
The "Drop One" command is useful when dropping a single item from a stack to keep a door open.  For example, a piece of plastic.

See the Configuration section below to change hot keys.

Both hotkeys can be configured.  See the Configuration section below.

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

[h2]3.1.0[/h2]
[list]
[*]0.9.7+ Only
[*]Added MCM support for key binding.
[*]Fix for sort key invoked while in space.  Missed in previous update.
[*]Internal - Upgraded MCM configuration and all related requirements to the latest versions.
[/list]

[h1]Change Log[/h1]

[h2]2.4.1[/h2]
[list]
[*]Multi version support.
[/list]

[h2]2.4.0[/h2]
[list]
[*]Drop All now always closes screen.  Useful for muscle memory when opening a barrel and not realizing it was empty.
[/list]

[h2]2.3.0[/h2]
[list]
[*]MCM integration.
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
