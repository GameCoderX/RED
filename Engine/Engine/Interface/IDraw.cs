using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Interface
{
    public interface IDraw
    {
        Boolean visibility
        {
            get;
            set;
        }

        void Initialize();
        void Input();
        void Update(GameTime gameTime);
        void Draw();
    }
}
