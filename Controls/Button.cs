using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookieClicker.Controls
{
    public class Button : MyComponent
    {

        private MouseState _currentMouse;

        private SpriteFont _font;

        private SpriteFont _fontSmall;

        private bool _isHovering;

        private MouseState _previousMouse;

        private Texture2D _texture;
        private Texture2D texture2D;
        private SpriteFont spriteFont;

        public event EventHandler click;

        public bool Clicked { get; private set; }

        public Color PenColour { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public string Text { get; set; }

        public string Price { get; set; }

        public Button(Game game, Texture2D texture, SpriteFont font) 
        {
            _texture = texture;

            _font = font;
            _fontSmall = game.Content.Load<SpriteFont>("Fonts/galleryFontSmall");
            PenColour = Color.Black;
        }

        //public Button(Game game, Vector2 position, string text, decimal price)
        //{
        //    _texture = game.Content.Load<Texture2D>("Controls/Button");
        //    _font = game.Content.Load<SpriteFont>("Fonts/galleryFont");
        //    _fontSmall = game.Content.Load<SpriteFont>("Fonts/galleryFontSmall");
        //    Text = text;
        //    Position = position;
        //    Price="Price: "+price;
        //}

        public Button(Texture2D texture2D, SpriteFont spriteFont)
        {
            this.texture2D = texture2D;
            this.spriteFont = spriteFont;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            if (_isHovering)
                colour = Color.Gray;

            spriteBatch.Draw(_texture, Rectangle, colour);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width - 350)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }

            if (!string.IsNullOrEmpty(Price))
            {
                var x = (Rectangle.X + (Rectangle.Width - 270)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_fontSmall, Price, new Vector2(x + 200, y + 10), PenColour);
            }
        
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if(_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    click?.Invoke(this, new EventArgs());
                }
            }
        
        }




    }
}
