using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Drawing;
using Engine.Menu;

namespace Engine.Engine
{
    public class EConsole
    {
        private MText headLine;
        private MInput userinput;
        private SpriteBatch _spriteBatch;
        private KeyboardState keyboardState;

        public EConsole(SpriteBatch spriteBatch)
        {
            keyboardState = new KeyboardState();
            _spriteBatch = spriteBatch;
            headLine = new MText(_spriteBatch, new Vector2(10, 45), "", GameMain.fontTest);
            userinput = new MInput(_spriteBatch, new Vector2(10, 10), "", GameMain.fontTest, keyboardState);
        }

        public void Initialize()
        {
            headLine.Initialize();
            userinput.Initialize();
            userinput.color = Color.Black;
            headLine.font = GameMain.fontTest;
            userinput.font = GameMain.fontTest;
        }
        public String Input()
        {
            userinput.Input();
            if (userinput.inputFinished && userinput.inputText != "")
            {
                String inputCommand = userinput.inputText;
                userinput.ResetInput();
                return inputCommand;
            }
            return "/";
        }

        public void Output(String output, Color color)
        {
            headLine.text = output;
            headLine.color = color;
        }

        public void Update(GameTime gameTime)
        {
            
        }
        public void Draw()
        {
            
            DDrawing.Rectangle(_spriteBatch, new Rectangle(0, 0, 1280, 75), Color.White);
            DDrawing.Rectangle(_spriteBatch, new Rectangle(5, 5, 1270, 30), Color.Black, 2);
            DDrawing.Rectangle(_spriteBatch, new Rectangle(5, 40, 1270, 30), Color.Black);

            headLine.Draw();
            userinput.Draw();
        }
    }
}
