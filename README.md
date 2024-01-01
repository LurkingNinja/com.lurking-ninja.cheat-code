# Cheat Codes
Building and listening to cheat codes typed or inputted by the users. This package requires Unity's InputSystem.
## Installation
You can choose manually installing the package or from GitHub source.
### Add package from git URL
Use the Package Manager's ```+/Add package from git URL``` function.
The URL you should use is this:
```
https://github.com/LurkingNinja/com.lurking-ninja.cheat-codes.git?path=Packages/com.lurking-ninja.cheat-codes
```
### Manual install
1. Download the latest ```.zip``` package from the [Release](https://github.com/LurkingNinja/com.lurking-ninja.cheat-codes/releases) section.
2. Unpack the ```.zip``` file into your project's ```Packages``` folder.
3. Open your project and check if it is imported properly.
## Usage
Usage is fairly simple, but it has two ways, depending if you have installed the [com.lurking-ninja.player-loop](https://github.com/LurkingNinja/com.lurking-ninja.player-loop) package.
### With the Playerloop package:
```csharp
using UnityEngine;

namespace LurkingNinja.CheatCode.Samples
{
    public class PlayerloopSample : MonoBehaviour
    {
        private void Awake() => new CheatCodes("iddqd", IddqdExecute);

        private static void IddqdExecute() => Debug.Log("iddqd executed.");

    }
}
```
This can be used without MonoBehaviour, obviously, this sample uses one just for the simplicity. You can also add additional codes to look for to the same CheatCodes objects by storing the object and executing additional TryAddCode method(s) on it. See Samples for details.

### Without the Playerloop package:
```csharp
using UnityEngine;

namespace LurkingNinja.CheatCode.Samples
{
    public class MonoBehaviourSample : MonoBehaviour
    {
        private CheatCodes _cheatCodes;
        
        private void Awake() => _cheatCodes = new CheatCodes("iddqd", IddqdExecute);

        private void Update() => _cheatCodes.OnUpdate();

        private static void IddqdExecute() => Debug.Log("iddqd executed.");
    }
}
```
The package also contain a CheatCodeBuilder class which is using the chainable builder-pattern.
The usage is fairly simple:
```csharp
CheatCodeBuilder
    .NewCode("id")
        .Append("ddqd");
```
or mixed input (this will expect to hit the i and d keys on a keyboard and then the South button on the game pad):
```csharp
CheatCodeBuilder
    .NewCode("id")
        .AppendButtonSouth();
```
The CheatCodeBuilder can be fed into the CheatCodes class directly (both in constructor and in TryAddCode).

Important note that key strokes should and are stored in lowercase characters and other input (as of today Mouse and generic Gamepad) input pieces are stored in capitalized codes.