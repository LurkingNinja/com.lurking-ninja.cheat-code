/***
 * Cheat Codes
 * Copyright (c) 2022-2024 Lurking Ninja.
 *
 * MIT License
 * https://github.com/LurkingNinja/com.lurking-ninja.cheat-code
 */
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LurkingNinja.CheatCode
{
    public class CheatCodeBuilder
    {
	    public const string MouseLeftButton = "LMB";
	    public const string MouseMiddleButton = "MMB";
	    public const string MouseRightButton = "RMB";
		
	    public const string ButtonNorth = "GBN";
	    public const string ButtonSouth = "GBS";
	    public const string ButtonEast = "GBE";
	    public const string ButtonWest = "GBW";
		
	    public const string Start = "GBT";
	    public const string Select = "GBL";
		
	    public const string RightStickUp = "GRSU";
	    public const string RightStickDown = "GRSD";
	    public const string RightStickLeft = "GRSL";
	    public const string RightStickRight = "GRSR";
		
	    public const string LeftStickUp = "GLSU";
	    public const string LeftStickDown = "GLSD";
	    public const string LeftStickLeft = "GLSL";
	    public const string LeftStickRight = "GLSR";
		
	    public const string DpadUp = "GDU";
	    public const string DpadDown = "GDD";
	    public const string DpadLeft = "GDL";
	    public const string DpadRight = "GDR";
		
	    public const string LeftShoulder = "GLS";
	    public const string RightShoulder = "GRS";
		
	    public const string LeftTrigger = "GLT";
	    public const string RightTrigger = "GRT";

	    private readonly StringBuilder _builder = new();

        public static CheatCodeBuilder NewCode(string code, bool preformatted = false) => new(code, preformatted);
        public static CheatCodeBuilder NewCode() => new();

        public CheatCodeBuilder(string code, bool preformatted = false) : this()  =>
	        _builder.Append(preformatted ? code : code.ToLower());

        public CheatCodeBuilder() => Clear();

        public CheatCodeBuilder Clear()
        {
	        _builder.Clear();
	        return this;
        }

        public CheatCodeBuilder Append(string code)
        {
            _builder.Append(code.ToLower());
            return this;
        }

		public CheatCodeBuilder Append(KeyCode code)
		{
			_builder.Append(code.ToString().ToLower());
			return this;
		}

		public CheatCodeBuilder Append(Key code)
		{
			_builder.Append(code.ToString().ToLower());
			return this;
		}

		public CheatCodeBuilder AppendMouseLeftButton()
		{
			_builder.Append(MouseLeftButton);
			return this;
		}

		public CheatCodeBuilder AppendMouseMiddleButton() {
			_builder.Append(MouseMiddleButton);
			return this;
		}
		
		public CheatCodeBuilder AppendMouseRightButton() {
			_builder.Append(MouseRightButton);
			return this;
		}
		
		public CheatCodeBuilder AppendButtonNorth() {
			_builder.Append(ButtonNorth);
			return this;
		}
		
		public CheatCodeBuilder AppendButtonSouth() {
			_builder.Append(ButtonSouth);
			return this;
		}
		
		public CheatCodeBuilder AppendButtonEast() {
			_builder.Append(ButtonEast);
			return this;
		}
		
		public CheatCodeBuilder AppendButtonWest() {
			_builder.Append(ButtonWest);
			return this;
		}
		
		public CheatCodeBuilder AppendStart() {
			_builder.Append(Start);
			return this;
		}
		
		public CheatCodeBuilder AppendSelect() {
			_builder.Append(Select);
			return this;
		}
		
		public CheatCodeBuilder AppendRightStickUp() {
			_builder.Append(RightStickUp);
			return this;
		}
		
		public CheatCodeBuilder AppendRightStickDown() {
			_builder.Append(RightStickDown);
			return this;
		}
		
		public CheatCodeBuilder AppendRightStickLeft() {
			_builder.Append(RightStickLeft);
			return this;
		}
		
		public CheatCodeBuilder AppendRightStickRight() {
			_builder.Append(RightStickRight);
			return this;
		}
	
		public CheatCodeBuilder AppendLeftStickUp() {
			_builder.Append(LeftStickUp);
			return this;
		}
		
		public CheatCodeBuilder AppendLeftStickDown() {
			_builder.Append(LeftStickDown);
			return this;
		}
		
		public CheatCodeBuilder AppendLeftStickLeft() {
			_builder.Append(LeftStickLeft);
			return this;
		}
		
		public CheatCodeBuilder AppendLeftStickRight() {
			_builder.Append(LeftStickRight);
			return this;
		}
		
		public CheatCodeBuilder AppendDpadUp() {
			_builder.Append(DpadUp);
			return this;
		}
		
		public CheatCodeBuilder AppendDpadDown() {
			_builder.Append(DpadDown);
			return this;
		}
		
		public CheatCodeBuilder AppendDpadLeft() {
			_builder.Append(DpadLeft);
			return this;
		}
		
		public CheatCodeBuilder AppendDpadRight() {
			_builder.Append(DpadRight);
			return this;
		}
		
		public CheatCodeBuilder AppendLeftShoulder() {
			_builder.Append(LeftShoulder);
			return this;
		}
		
		public CheatCodeBuilder AppendRightShoulder() {
			_builder.Append(RightShoulder);
			return this;
		}
		
		public CheatCodeBuilder AppendLeftTrigger() {
			_builder.Append(LeftTrigger);
			return this;
		}
		
		public CheatCodeBuilder AppendRightTrigger() {
			_builder.Append(RightTrigger);
			return this;
		}

		public override string ToString() => _builder.ToString();
    }
}