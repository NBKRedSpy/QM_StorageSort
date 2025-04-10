[h1]Storage Sort and Drop[/h1]


[h1]Beta Only[/h1]

Currently this only supports the opt in beta.

[h1]Docs[/h1]

Sorts or drops all items in a container.
By default S sorts and D drops all items.

The drop key is useful when dropping gas from barrels.

See the Configuration section below to change hot keys.

Sorts containers in raids with a hotkey.  Defaults to S.
For example, corpse piles, containers, and floor items.

Also can drop all items in a container by pressing the D key.  Particularly useful when emptying gas barrels.

Both hotkeys can be configured.  See the Configuration section below.

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

The list of valid keyboard keys can be found  at the bottom of https://docs.unity3d.com/ScriptReference/KeyCode.html
Beware that numbers 0-9 are Alpha0 - Alpha9.  Most of the other keys are as expected such as X for X.
Use "None" to not bind the key.

[h1]Support[/h1]

If you enjoy my mods and want to buy me a coffee, check out my [url=https://ko-fi.com/nbkredspy71915]Ko-Fi[/url] page.
Thanks!

[h1]Source Code[/h1]

Source code is available on GitHub at https://github.com/NBKRedSpy/QM_StorageSort

[h1]Change Log[/h1]

[h2]2.0.0[/h2]
[list]
[*]Added Drop All key.
[/list]
