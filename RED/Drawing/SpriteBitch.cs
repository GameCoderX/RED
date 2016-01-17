using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RED.Drawing
{
    public class SpriteBitch : SpriteBatch
    {
        private Texture2D blankTexture;

        public SpriteBitch(GraphicsDevice graphicsdevice)
            : base(graphicsdevice)
        {
            //Initialize the drawing texture with a 1x1 pixel sized Rectangle with the color white
            blankTexture = new Texture2D(this.GraphicsDevice, 1, 1);
            blankTexture.SetData(new Color[] { Color.White });
        }

        public void DrawRectangle(Rectangle rect, Color color, int thickness)
        {
            this.FillRectangle( new Rectangle(rect.X, rect.Y, rect.Width, thickness), color);

            this.FillRectangle( new Rectangle(rect.X + rect.Width - thickness, rect.Y, thickness, rect.Height), color);

            this.FillRectangle( new Rectangle(rect.X, rect.Y + rect.Height - thickness, rect.Width, thickness), color);

            this.FillRectangle( new Rectangle(rect.X, rect.Y, thickness, rect.Height), color);
        }

        public void FillRectangle(Rectangle rect, Color color)
        {
            this.Draw(blankTexture, rect, color);
        }
    }
}
