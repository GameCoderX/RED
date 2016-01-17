using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RED.Drawing;

namespace RED.Controls
{
    public abstract class Control : IDraw
    {
        protected Vector2 _pos;
        protected Boolean _visibility;
        protected SpriteBitch _SpriteBitch;

       public Vector2 pos
        {
            get
            {
                return this._pos;
            }
            set
            {
                this._pos = value;
            }
        }

       public Boolean visibility
        {
            get
            {
                return this._visibility;
            }
            set
            {
                this._visibility = value;
            }
        }

       public abstract void Initialize();
       public abstract void Input();
       public abstract void Update(GameTime gameTime);
       public abstract void Draw();
    }
}
