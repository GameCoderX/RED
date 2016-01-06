using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Engine
{
    class EInterpreter
    {
        private EConsole _console;
        private Game _gameJoin;

        public EInterpreter(Game gameJoin, EConsole console)
        {
            _console = console;
            _gameJoin = gameJoin;
        }

        public void Initialize()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            

        }

        public void Draw()
        {
            
        }


        public void Interpret(String command)
        {
            String[] parts = command.Split(' ');
            switch (parts[0])
            {
                case "/": break;// Do nothing
                case "/exit": CommandDone("1"); _gameJoin.Exit(); break; //Exit Game
                case "/test": CommandDone("0"); break; //Test Game
                default: _console.Output("#Command >" + parts[0] + "< not found!", Color.Red); break;
            }
        }

        private void CommandDone(String result)
        {
            _console.Output("#Done with result: " + result, Color.Green);
        }
    }
}
