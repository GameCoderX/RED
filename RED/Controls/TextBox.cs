using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using RED.Drawing;

namespace RED.Controls
{
    public class TextBox : Control
    {
        
        private String _text;
        private SpriteFont _font;
        private Color _color;


        public TextBox(SpriteBitch SpriteBitch, Vector2 pos, String text, SpriteFont font)
        {
            _pos = pos;
            _text = text;
            _font = font;
            _color = Color.White;
            _visibility = false;
            _SpriteBitch = SpriteBitch;
        }

 
        public String Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }
        public SpriteFont font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
            }
        }
        public Color color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
    
        public override void Initialize()
        {
            _visibility = true;
        }
        public override void Input()
        {
        }
        public override void Update(GameTime gameTime)
        {
        }
        
        public override void Draw()
        {
            if (visibility)
            {
                _SpriteBitch.Begin();
                _SpriteBitch.DrawString(_font, this.Text, _pos, _color);
                _SpriteBitch.End();
            }
        }
    }
}
