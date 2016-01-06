using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Drawing
{
    class DDrawing
    {
        private static Texture2D blankTexture;
        public static void Initialize(SpriteBatch spriteBatch)
        {
            blankTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            blankTexture.SetData(new Color[] { Color.White });
        }
        public static void Rectangle(SpriteBatch spriteBatch,Rectangle rect,Color color)
        {
            spriteBatch.Draw(blankTexture, rect, color);
        }

        public static void Rectangle(SpriteBatch spriteBatch, Rectangle rect, Color color, int thickness)
        {
            Rectangle(spriteBatch, new Rectangle(rect.X, rect.Y, rect.Width, thickness), color);
            Rectangle(spriteBatch, new Rectangle(rect.X + rect.Width - thickness, rect.Y, thickness, rect.Height), color);
            Rectangle(spriteBatch, new Rectangle(rect.X, rect.Y + rect.Height - thickness, rect.Width, thickness), color);
            Rectangle(spriteBatch, new Rectangle(rect.X, rect.Y, thickness, rect.Height), color);

        }
    }
}
