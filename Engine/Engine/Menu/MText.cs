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



namespace Engine.Menu
{
    public class MText : MObject
    {
        
        private String _text;
        private SpriteFont _font;
        private Color _color;


        public MText(SpriteBatch spriteBatch, Vector2 pos, String text, SpriteFont font)
        {
            _pos = pos;
            _text = text;
            _font = font;
            _color = Color.White;
            _visibility = false;
            _spriteBatch = spriteBatch;
        }

 
        public String text
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
                _spriteBatch.DrawString(_font, _text, _pos, _color);
            }
        }
    }
}
