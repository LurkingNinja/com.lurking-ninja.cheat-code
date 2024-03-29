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
    public class MonoBehaviourSample : MonoBehaviour
    {
        private CheatCodes _cheatCodes;
        
        private void Awake()
        {
            _cheatCodes = new CheatCodes("iddqd", IddqdExecute);
            _cheatCodes.TryAddCode("abc", AbcExecute);
        }

        private void Update() => _cheatCodes.OnUpdate();

        private static void IddqdExecute() => Debug.Log("iddqd executed.");

        private static void AbcExecute() => Debug.Log("abc executed.");
    }
}