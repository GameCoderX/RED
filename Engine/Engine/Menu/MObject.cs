using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Interface;

namespace Engine.Menu
{
    public abstract class MObject : IDraw
    {
        protected Vector2 _pos;
        protected Boolean _visibility;
        protected SpriteBatch _spriteBatch;

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
