/***
 * Cheat Codes
 * Copyright (c) 2022-2024 Lurking Ninja.
 *
 * MIT License
 * https://github.com/LurkingNinja/com.lurking-ninja.cheat-code
 */
using UnityEngine;

namespace LurkingNinja.CheatCode.Samples
{
    public class PlayerLoopSample : MonoBehaviour
    {
        private void Awake()
        {
            var cheatCodes = new CheatCodes("iddqd", IddqdExecute);
            cheatCodes.TryAddCode("abc", AbcExecute);
        }

        private static void IddqdExecute() => Debug.Log("iddqd executed.");

        private static void AbcExecute() => Debug.Log("abc executed.");
    }
}
