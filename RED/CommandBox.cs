using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RED.Drawing;
using RED.Controls;

namespace RED
{
    public class CommandBox : RED.Interfaces.ICommandExecuter
    {
        private REDGame itsGame;

        private SpriteBitch _SpriteBitch;
        private KeyboardState keyboardState;

        CommandSubject _commandSubject;
        public CommandSubject CommandEntered
        {
            get
            {
                return this._commandSubject;
            }

            private set
            {
                this._commandSubject = value;
            }
        }

        public CommandBox(REDGame game)
        {
            keyboardState = new KeyboardState();
            this.itsGame = game;

            //create a CommandSubject-object to enable observers to observe this CommandBox
            this.CommandEntered = new CommandSubject();
            //subscribe to the CommandEntered-subject
            this.CommandEntered.AddObserver(this);

        }

        public TextBox consoleOut;

        public InputBox consoleIn;

        public void Initialize(SpriteBitch spritebitch, SpriteFont font)
        {
            consoleOut = new TextBox(spritebitch, new Vector2(10, 45), "", font);
            consoleIn = new InputBox(spritebitch, new Vector2(10, 10), "", font, keyboardState);


            this._SpriteBitch = spritebitch;
            consoleOut.Initialize();
            consoleIn.Initialize();
        }

        public void Input()
        {
            consoleIn.Input();
            if (consoleIn.inputFinished)
            {
                String inputCommand = consoleIn.Text;

                //check if a command is entered
                    if (inputCommand.Split(' ').Length >= 1)
                    {
                        //get the command (word) out of the entered string
                        string command = inputCommand.Contains(' ') ? inputCommand.Substring(0, inputCommand.IndexOf(' ')) : inputCommand;
                        //get all arguments which were followed by the command (seperated with a space (each))
                        string[] arguments = new string[0];
                        if(inputCommand.Contains(' '))
                             arguments = inputCommand.Substring(inputCommand.IndexOf(' ') + 1).Split(' ');

                        //inform all observers that a command was entered!
                        CommandEventArgs commandEventArgs = new CommandEventArgs(command, arguments);
                        this.CommandEntered.Notify(this, commandEventArgs);      
                        //inform user that command couldn't be processed if it hasn't been
                        if (commandEventArgs.CommandProcessed == false)
                            this.Output(string.Format("Command \"{0}\" has not been found!", commandEventArgs.Command), Color.DarkRed);
                   }

                consoleIn.ResetInput();
            }
        }

        public void Output(String output, Color color)
        {
            consoleOut.Text = output;
            consoleOut.color = color;
        }

        public void Update(GameTime gameTime)
        {
            
        }
        public void Draw()
        {
            _SpriteBitch.Begin();
            _SpriteBitch.DrawRectangle(new Rectangle(5, 5, 1270, 30), Color.Blue, 2);
            _SpriteBitch.DrawRectangle(new Rectangle(5, 40, 1270, 30), Color.Blue, 2);
            _SpriteBitch.End();

            consoleOut.Draw();
            consoleIn.Draw();
        }

        private string[] CleanStringArray(string[] arrClean)
        {
            int newLength = 0;
            for (int i = 0; i < arrClean.Length; i++)
            {
                if (arrClean[i] != "")
                {
                    newLength++;
                }
            }

            string[] returnArr = new string[newLength];
            int returnIndex = 0;

            for (int i = 0; i < arrClean.Length; i++)
            {
                if (arrClean[i] != "")
                {
                    returnArr[returnIndex] = arrClean[i];
                    returnIndex++;
                }
            }

            return returnArr;
        }

        private double CalculateFromArray(string[] arrCalculate)
        {
            string[] arrOperation =
        {
            "^",
            "÷",
            "/",
            "*",
            "-",
            "+"
        };
            for (int OpIndex = 0; OpIndex < arrOperation.Length; OpIndex++)
            {
                for (int i = 0; i < arrCalculate.Length; i++)
                {
                    if (arrCalculate[i] == arrOperation[OpIndex])
                    {
                        arrCalculate[i] = Convert.ToString(SelectCalculation(Convert.ToDouble(arrCalculate[i - 1]), arrOperation[OpIndex], Convert.ToDouble(arrCalculate[i + 1])));
                        arrCalculate[i - 1] = "";
                        arrCalculate[i + 1] = "";
                        arrCalculate = CleanStringArray(arrCalculate);
                        i = 0;
                    }
                }

            }

            return Convert.ToDouble(arrCalculate[0]);
        }

        private double SelectCalculation(double number1, string operation, double number2)
        {
            double returnValue = 0;

            switch (operation)
            {
                case "+": returnValue = number1 + number2; break;
                case "-": returnValue = number1 - number2; break;
                case "*": returnValue = number1 * number2; break;
                case "÷": returnValue = number1 / number2; break;
                case "/": returnValue = number1 / number2; break;

                case "^": returnValue = Math.Pow(number1, number2); break;
                default:
                    break;
            }

            return returnValue;
        }

        public void OnCommandEntered(object sender, EventArgs e)
        {
            CommandEventArgs commandEventArgs = e as CommandEventArgs;

            switch(commandEventArgs.Command)
            {
                case "echo":
                    string strEcho = "";
                    int count = 0;
                    foreach (string arg in commandEventArgs.Arguments)
                    {
                        if (count++ != 0)
                            strEcho += ' ';
                        strEcho += arg.Replace("\"","").Replace("\'","");
                    }
                    Output(strEcho, Color.Yellow); 
                    commandEventArgs.CommandProcessed=true;
                    break;

                case "calc":
                    {
                        string strOut="";
                        foreach (string argument in commandEventArgs.Arguments)
                        {
                            strOut +=argument+" ";
                        }
                        Output(string.Format(strOut + "= {0}", CalculateFromArray(commandEventArgs.Arguments.ToArray())), Color.DarkSlateGray);
                        commandEventArgs.CommandProcessed = true;
                    }
                    break;
            }
        }
    }



}
