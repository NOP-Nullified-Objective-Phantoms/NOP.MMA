### Description

```cs
namespace NOP.MMA.Core
```
```cs
public class Debug
```
#### `Inheritance: Debug ->`

### Fields
| Access | Type | Name | Description
|---|---|---|---|
private static | [FileHandler](https://github.com/NOP-Nullified-Objective-Phantoms/NOP.Common/blob/Development/WiKiPages/FileHandler.md) | File | 

### Properties
Access | Type | Name | Description
|---|---|---|---|
public static | `string` | LogPath | The fully qualified path to the folder that contains all log files
public static | `DateTime` | LastLogged | The date and time of the last time an entry was logged

### Methods
Access | Return Type | Definition | Description |
|---|---|---|---|
private static | `bool` | NoHandler() | Check whether or not there's a [FileHandler](https://github.com/NOP-Nullified-Objective-Phantoms/NOP.Common/blob/Development/WiKiPages/FileHandler.md) attached to the debugge. Returns `True` if there's no [FileHandler](https://github.com/NOP-Nullified-Objective-Phantoms/NOP.Common/blob/Development/WiKiPages/FileHandler.md) attached, otherwise, `False`
private static | `void` | CreateHandler() | Creates a new [FileHandler](https://github.com/NOP-Nullified-Objective-Phantoms/NOP.Common/blob/Development/WiKiPages/FileHandler.md) if there's no handler already attached to the debugger, or if the last logged entry is more than an hour old
public static | `void` | Log(`string`) | Log a message to the log file
public static | `void` | LogError(`Exception`) | Log an `Exception` to the log file
public static | `void` | LogError(`string`,`Exception`,`bool`) | Log an `Exception` to the log file with a custom message
public static | `void` | LogWarning(`string`) | Log a warning to the log file

### Code Example
```cs
public static void Main (string[] args)
{
    Debug.Log ("Hello, World!");
}
```