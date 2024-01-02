/***
 * Cheat Codes
 * Copyright (c) 2022-2024 Lurking Ninja.
 *
 * MIT License
 * https://github.com/LurkingNinja/com.lurking-ninja.cheat-code
 */
using System;
using System.Collections.Generic;
using System.Text;
#if LN_PLAYER_LOOP_ENABLED
using LurkingNinja.PlayerLoop;
#endif
using UnityEngine;
using UnityEngine.InputSystem;

namespace LurkingNinja.CheatCode
{
	public class CheatCodes
#if LN_PLAYER_LOOP_ENABLED
		: IUpdate
#endif
	{
		public float DefaultGamepadClearAfter = .75f; 

		private float _timeUntilClear;

		private readonly InputAction _anyKeyWait = new(type:InputActionType.Button);
		private readonly string[] _controls = {
				"/<Mouse>/leftButton", "/<Mouse>/middleButton", "/<Mouse>/rightButton", "/<Gamepad>/buttonNorth",
				"/<Gamepad>/buttonSouth", "/<Gamepad>/buttonEast", "/<Gamepad>/buttonWest","/<Gamepad>/start",
				"/<Gamepad>/select", "/<Gamepad>/rightStick/up", "/<Gamepad>/rightStick/down", "/<Gamepad>/rightStick/left",
				"/<Gamepad>/rightStick/right", "/<Gamepad>/leftStick/up", "/<Gamepad>/leftStick/down",
				"/<Gamepad>/leftStick/left", "/<Gamepad>/leftStick/right", "/<Gamepad>/dpad/up", "/<Gamepad>/dpad/down",
				"/<Gamepad>/dpad/left", "/<Gamepad>/dpad/right", "/<Gamepad>/leftShoulder", "/<Gamepad>/rightShoulder",
				"/<Gamepad>/leftTrigger", "/<Gamepad>/rightTrigger"
		};

		private readonly string[] _codes = {
				CheatCodeBuilder.MouseLeftButton, CheatCodeBuilder.MouseMiddleButton, CheatCodeBuilder.MouseRightButton,
				CheatCodeBuilder.ButtonNorth, CheatCodeBuilder.ButtonSouth, CheatCodeBuilder.ButtonEast,
				CheatCodeBuilder.ButtonWest, CheatCodeBuilder.Start, CheatCodeBuilder.Select,
				CheatCodeBuilder.RightStickUp, CheatCodeBuilder.RightStickDown, CheatCodeBuilder.RightStickLeft,
				CheatCodeBuilder.RightStickRight, CheatCodeBuilder.LeftStickUp, CheatCodeBuilder.LeftStickDown,
				CheatCodeBuilder.LeftStickLeft, CheatCodeBuilder.LeftStickRight, CheatCodeBuilder.DpadUp,
				CheatCodeBuilder.DpadDown, CheatCodeBuilder.DpadLeft, CheatCodeBuilder.DpadRight,
				CheatCodeBuilder.LeftShoulder, CheatCodeBuilder.RightShoulder, CheatCodeBuilder.LeftTrigger,
				CheatCodeBuilder.RightTrigger
		};

		private readonly StringBuilder _builder = new();
		private readonly List<string> _addedCodes = new();
		private readonly List<Action> _addedCallbacks = new();

		public bool TryAddCode(string code, Action listener) => AddCode(code.ToLower(), listener);

		public bool TryAddCode(CheatCodeBuilder codeBuilder, Action listener) =>
			AddCode(codeBuilder.ToString(), listener);

		private bool AddCode(string code, Action listener)
		{
			if (HasCode(code)) return false;
			_addedCodes.Add(code);
			_addedCallbacks.Add(listener);
#if LN_PLAYER_LOOP_ENABLED
			PlayerLoop.PlayerLoop.AddListener(this);
#endif
			return true;
		}

		public bool HasCode(string code) => _addedCodes.Contains(code.ToLower());

		public bool IsEmpty => _addedCodes.Count == 0;
		
		public void Clear()
		{
			_addedCodes.Clear();
			_addedCallbacks.Clear();
		}
		
		public CheatCodes()
		{
			for (var i = 0; i < _controls.Length - 1; i++)
			{
				_anyKeyWait.AddBinding(_controls[i]);
				_controls[i] = _controls[i].Replace("/<Gamepad>/", string.Empty)
						.Replace("/<Mouse>/", string.Empty);
			}
			Clear();
			Enable();
		}

		public CheatCodes(string code, Action listener) : this() => TryAddCode(code, listener);
		
		public CheatCodes(CheatCodeBuilder codeBuilder, Action listener) : this() => TryAddCode(codeBuilder, listener);

		public void Enable()
		{
			_anyKeyWait.performed += InputMouseGamepad;
			Keyboard.current.onTextInput += InputKey;
			_anyKeyWait.Enable();
		}

		public void Disable()
		{
			StopTimer();
			_anyKeyWait.performed -= InputMouseGamepad;
			Keyboard.current.onTextInput -= InputKey;
			_anyKeyWait.Disable();
		}

		private void InputKey(char inputChar)
		{
			_builder.Append(inputChar.ToString().ToLower());
			_timeUntilClear = 0;
			CheckCodes();
		}

		private void InputMouseGamepad(InputAction.CallbackContext ctx)
		{
			for(var i = 0; i < _controls.Length; i++)
			{
				if (!ctx.control.path.EndsWith(_controls[i])) continue;
				_builder.Append(_codes[i]);
				_timeUntilClear = 0f;
				CheckCodes();
				return;
			}		
		}
		
		private void CheckCodes()
		{
			var str = _builder.ToString();
			for(var i = _addedCodes.Count - 1; i >= 0; i--)
			{
				if (!str.Equals(_addedCodes[i])) continue;
				_builder.Clear();
				_addedCallbacks[i]?.Invoke();
				return;

			}
			StartTimer();
		}

		private void StartTimer() => _timeUntilClear = DefaultGamepadClearAfter;
		
		private void StopTimer() => _timeUntilClear = 0;

		public void OnUpdate()
		{
			if (Mathf.Approximately(_timeUntilClear, 0f) || _builder.Length == 0)
				return;

			_timeUntilClear -= Time.deltaTime;

			if (!(_timeUntilClear <= 0f)) return;

			_timeUntilClear += DefaultGamepadClearAfter;
			_builder.Clear();
			StopTimer();
		}
	}
}