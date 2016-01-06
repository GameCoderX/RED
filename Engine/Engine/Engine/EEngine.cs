using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Engine
{
    public class EEngine
    {
        private EConsole _console;
        private EInterpreter _interpreter;
        private String _command;
        public EConsole console
        {
            get
            {
                return _console;
            }
            set
            {
                _console = value;
            }
        }
        public EEngine()
        {
            
        }

        public void Initialize(Game gameJoin)
        {
            _console.Initialize();
            _interpreter = new EInterpreter(gameJoin, _console);
        }

        public void Input()
        {
            _command = _console.Input();
        }

        public void Update(GameTime gameTime)
        {
            _console.Update(gameTime);
            _interpreter.Update(gameTime);
            _interpreter.Interpret(_command);
        }

        public void Draw()
        {
            _console.Draw();
        }
    }
}
