using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RED.Drawing;
namespace RED.Controls
{
    public class InputBox : TextBox
    {

        private KeyboardState _keyboard;
        private KeyboardState _keyboardOld;
        private Boolean _inputFinished;
        private int _cursor = 0;

        enum KeyState : byte
        {
            Idle=0,
            ShiftPressed=1,
            CapslockPressed=2
        }
        private KeyState currentKeyState;

        public InputBox(SpriteBitch SpriteBitch, Vector2 pos, String text, SpriteFont font, KeyboardState keyboard)
            : base(SpriteBitch, pos, text, font)
        {
            _visibility = false;
            _keyboard = keyboard;
            this.Text = "";
            _inputFinished = false;
        }

        public Boolean inputFinished
        {
            get
            {
                return _inputFinished;
            }
            set
            {
                _inputFinished = value;
            }
        }

        public KeyboardState keyboard
        {
            get
            {
                return _keyboard;
            }
            set
            {
                _keyboard = value;
            }
        }


        public override void Initialize()
        {
            this.Text = "";
            _inputFinished = false;
            _visibility = true;

        }
        public override void Input()
        {
            _keyboardOld = _keyboard;
            _keyboard = Keyboard.GetState();
            String inputString = "";
            foreach (Keys key in _keyboard.GetPressedKeys())
            {
                inputString = "";
                if (_keyboardOld.IsKeyUp(key))
                {
                    if (key >= Keys.D0 && key <= Keys.Z)
                    {
                        inputString = ((char)key).ToString();

                    }
                    
                    switch(key) //Switch for other keys without shift
                    {
                        case Keys.Back:
                            {
                                if (this.Text.Length > 0 && _cursor > 0)
                                {
                                    this.Text = this.Text.Remove(_cursor - 1, 1);
                                    _cursor -= 1;
                                    if (_cursor < 0)
                                        _cursor = 0;
                                }
                            }
                            break;

                        case Keys.Enter:
                            {
                                _inputFinished = this.Text!="";
                            }
                            break;
                        case Keys.NumPad0: inputString = "0"; break;
                        case Keys.NumPad1: inputString = "1"; break;
                        case Keys.NumPad2: inputString = "2"; break;
                        case Keys.NumPad3: inputString = "3"; break;
                        case Keys.NumPad4: inputString = "4"; break;
                        case Keys.NumPad5: inputString = "5"; break;
                        case Keys.NumPad6: inputString = "6"; break;
                        case Keys.NumPad7: inputString = "7"; break;
                        case Keys.NumPad8: inputString = "8"; break;
                        case Keys.NumPad9: inputString = "9"; break;

                        case Keys.Subtract: inputString = "-"; break;
                        case Keys.Add: inputString = "+"; break;
                        case Keys.Multiply: inputString = "*"; break;
                        case Keys.Divide: inputString = "/"; break;

                        case Keys.OemPeriod: inputString = "."; break;
                        case Keys.OemComma: inputString = ","; break;
                        case Keys.OemMinus: inputString = "-"; break;
                        case Keys.OemPlus: inputString = "+"; break;

                        case Keys.OemQuestion: inputString = "#"; break;
                        case Keys.OemBackslash: inputString = "<"; break;
                        case Keys.Space: inputString = " "; break;
                        case Keys.OemOpenBrackets: inputString = "\\"; break;
                        case Keys.Left: _cursor -= 1; 
                             if (_cursor < 0)
                                _cursor = 0;
                                break;
                        case Keys.Right: _cursor += 1;
                                if (_cursor > this.Text.Length)
                                    _cursor = this.Text.Length;
                                break;

                    }
                    if (_keyboard.IsKeyDown(Keys.CapsLock))
                    {
                        currentKeyState = currentKeyState == KeyState.CapslockPressed ? KeyState.Idle : KeyState.CapslockPressed;
                    }
                    if (currentKeyState != KeyState.CapslockPressed)
                    {
                        if (_keyboard.IsKeyDown(Keys.RightShift) ||
                            _keyboard.IsKeyDown(Keys.LeftShift))
                        {
                            currentKeyState = KeyState.ShiftPressed;
                        }
                        else
                        {
                            currentKeyState = KeyState.Idle;
                        }
                    }

                    if(currentKeyState == KeyState.ShiftPressed || currentKeyState == KeyState.CapslockPressed)
                    {
                        if (key >= Keys.A && key <= Keys.Z)
                        {
                            inputString = inputString.ToUpper();
                        }
                        else 
                        {
                            switch (inputString) //Switch for other keys with shift
                            {
                                case "0": inputString = "="; break;
                                case "1": inputString = "!"; break;
                                case "2": inputString = "\""; break;
                                case "3": inputString = "§"; break;
                                case "4": inputString = "$"; break;
                                case "5": inputString = "%"; break;
                                case "6": inputString = "&"; break;
                                case "7": inputString = "/"; break;
                                case "8": inputString = "("; break;
                                case "9": inputString = ")"; break;

                                case ".": inputString = ":";break;
                                case ",": inputString = ";";break;
                                case "-": inputString = "_"; break;
                                case "+": inputString = "*"; break;
                                case "#": inputString = "\'"; break;
                                case "<": inputString = ">"; break;
                                case "\\": inputString = "?"; break;
                                
                            }
                        }
                    }
                    else
                    {
                        inputString = inputString.ToLower();
                    }

                    if (this.Text.Length > 0 && this.Text.Length != _cursor)
                        this.Text = this.Text.Substring(0, _cursor) + inputString + this.Text.Substring(_cursor, this.Text.Length - (_cursor));
                    else
                        this.Text += inputString;

                    if (inputString != "")
                    _cursor += 1;
                }
            }


            if (this.Text.Length > 0 && this.Text.Length != _cursor)
                this.Text = this.Text.Substring(0, _cursor) + "_" + this.Text.Substring(_cursor, this.Text.Length - (_cursor));

           
        }

        public override void Update(GameTime gameTime)
        {

        }
        public override void Draw()
        {
            base.Draw();

        }

        public void ResetInput()
        {
            this.Text = "";
            _cursor = 0;
            _inputFinished = false;
        }
    }
}
