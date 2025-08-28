# Storage Sort, Drop, and Single Drop

![thumbnail icon](media/thumbnail.png)

# Docs

Sorts or drops all items in a container.  
By default S sorts and D drops all items.  
Adds the context menu command "Drop One".

The drop key is useful when dropping gas from barrels in one keystroke.
The "Drop One" command is useful when dropping a single item from a stack to keep a door open.  For example, a piece of plastic.

See the [Configuration](#configuration) section below to change hot keys.

Both hotkeys can be configured.  See the [Configuration](#configuration) section below.

# "Drop One" and Context Menu Hotkeys Mod
To add a hotkey to the "Drop One" function in the Context Menu Hotkeys mod, 

Add this to the list of keys in the Context Menu Hokeys config file:

```json
    {
      "Key": "F",
      "Command": 620000
    },

```

The above will add the key F as the hotkey when the context menu is open.


# Configuration

The configuration file will be created on the first game run and can be found at `%AppData%\..\LocalLow\Magnum Scriptum Ltd\Quasimorph_ModConfigs\StorageSort\config.json`.

|Name|Default|Description|
|--|--|--|
|SortKey|S|The key that sorts the current storage inventory|
|DropKey|D|Drops all items in a container.|

## Key List
The list of valid keyboard keys can be found at the bottom of https://docs.unity3d.com/ScriptReference/KeyCode.html
Beware that numbers 0-9 are Alpha0 - Alpha9.  Most of the other keys are as expected such as X for X.
Use "None" to not bind the key.

# Support
If you enjoy my mods and want to buy me a coffee, check out my [Ko-Fi](https://ko-fi.com/nbkredspy71915) page.
Thanks!

# Source Code
Source code is available on GitHub at https://github.com/NBKRedSpy/QM_StorageSort

# Credits
* Special thanks to Crynano for his excellent Mod Configuration Menu. 

# Change Log
## 2.3.0
* MCM integration.

## 2.1.0
* Added "Drop One" command.

## 2.0.1 
* Fixed mod config using key codes instead of the string version.
* Thanks goes to Steam user Traveler for reporting this issue.

## 2.0.0
* Added Drop All key.