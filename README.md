# Storage Sort and Drop

![thumbnail icon](media/thumbnail.png)

# Beta Only
Currently this only supports the opt in beta.

# Docs

Sorts or drops all items in a container.  
By default S sorts and D drops all items.  

The drop key is useful when dropping gas from barrels.

See the [Configuration](#configuration) section below to change hot keys.



Sorts containers in raids with a hotkey.  Defaults to S.
For example, corpse piles, containers, and floor items.

Also can drop all items in a container by pressing the D key.  Particularly useful when emptying gas barrels. 

Both hotkeys can be configured.  See the [Configuration](#configuration) section below.

# Configuration

The configuration file will be created on the first game run and can be found at `%AppData%\..\LocalLow\Magnum Scriptum Ltd\Quasimorph_ModConfigs\StorageSort\config.json`.

|Name|Default|Description|
|--|--|--|
|SortKey|S|The key that sorts the current storage inventory|
|DropKey|D|Drops all items in a container.|

## Key List
The list of valid keyboard keys can be found  at the bottom of https://docs.unity3d.com/ScriptReference/KeyCode.html
Beware that numbers 0-9 are Alpha0 - Alpha9.  Most of the other keys are as expected such as X for X.
Use "None" to not bind the key.

# Support
If you enjoy my mods and want to buy me a coffee, check out my [Ko-Fi](https://ko-fi.com/nbkredspy71915) page.
Thanks!

# Source Code
Source code is available on GitHub at https://github.com/NBKRedSpy/QM_StorageSort

# Change Log

## 2.0.0
* Added Drop All key.