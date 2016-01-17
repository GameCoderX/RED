using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RED.Drawing;
using RED.Controls;
using RED.Interfaces;

namespace RED
{
    public class REDGame : Game, ICommandExecuter
    {
        protected GraphicsDeviceManager Graphics;
        protected SpriteBitch SpriteBitch;

        private CommandBox _console;
        //initialize console in the inherit game
        public CommandBox Console
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


        public REDGame(string contentRootDirectory="")
        {
            this.Graphics = new GraphicsDeviceManager(this);

            this.Content.RootDirectory = contentRootDirectory;

            this._console = new CommandBox(this);
            //add observer to the CommandEntered-subject
            this.Console.CommandEntered.AddObserver(this);
        }

        protected override void Initialize( )
        {

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBitch, which can be used to draw textures.
            SpriteBitch = new SpriteBitch(GraphicsDevice);

            
        }

        protected override void UnloadContent()
        {

        }


        protected override void BeginRun()
        {


            base.BeginRun();
        }

        protected virtual void Input()
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            _console.Input();
        }

        protected override void Update(GameTime gameTime)
        {
            //Inputs
            this.Input();

            _console.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _console.Draw();

            base.Draw(gameTime);
        }

        public virtual void OnCommandEntered(object sender, EventArgs e)
        {
            CommandEventArgs commandEventArgs = (e as CommandEventArgs);
            
            switch (commandEventArgs.Command)
            {
                case "exit": 
                    this.Exit(); 
                    commandEventArgs.CommandProcessed = true; 
                    break;
                case "fullscreen": 
                    this.Graphics.ToggleFullScreen(); 
                    commandEventArgs.CommandProcessed = true; 
                    break;
            }
        }
    }
}
