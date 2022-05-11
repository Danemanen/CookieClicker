using CookieClicker.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.ComponentModel;

namespace CookieClicker
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<MyComponent> _gameComponents;

        
        Texture2D CookieSprite;
        Texture2D BackgroundSprite;
        Texture2D StoreSprite;
        SpriteFont gameFont;

        Vector2 Cookieposition = new Vector2(420, 450);
        const int CookieRadius = 300;
        
        MouseState mState;
        bool mReleased = true;
        int Cookies = 0;
        int Click = 1;
        int GrandmaPerSec = 0;
        int CursorPerSec = 0;
        int FarmPerSec = 0;
        int MinePerSec = 0;
        int FactoryPerSec = 0;
        int BankPerSec = 0;

        int secTimer = 0;





        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var cursorButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 200),
                Text = "Cursor",
            };

            cursorButton.click += CursorButton_click;

            var grandmaButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 285),
                Text = "Grandma",
            };

            grandmaButton.click += GrandmaButton_click;

            _gameComponents = new List<MyComponent>()
            {
               cursorButton,
               grandmaButton,
            };

            StoreSprite = Content.Load<Texture2D>("Store");
            CookieSprite = Content.Load<Texture2D>("Cookie");
            BackgroundSprite = Content.Load<Texture2D>("Background");
            gameFont = Content.Load<SpriteFont>("Fonts/galleryFont");
           
        }

        private void GrandmaButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= 5)
            {
                Cookies -= 5;
                GrandmaPerSec += 5;
            }
        }

        private void CursorButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= 1)
            {
                Cookies -= 1;
                CursorPerSec += 1;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            secTimer += 1;
            if (secTimer == 60)
            {
                Cookies += GrandmaPerSec;
                Cookies += CursorPerSec;
                secTimer = 0;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mState = Mouse.GetState();

            if (mState.LeftButton == ButtonState.Pressed && mReleased == true)
            {
                float mouseCookieDist = Vector2.Distance(Cookieposition, mState.Position.ToVector2());
                if(mouseCookieDist < CookieRadius)
                {
                    Cookies += Click;
                }
                mReleased = false;
            }

            if (mState.LeftButton == ButtonState.Released)
            {
                mReleased = true;
            }

            foreach (var component in _gameComponents)
                component.Update(gameTime);


            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(BackgroundSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(gameFont, "Cookies:" + " " + Cookies.ToString(), new Vector2(50, 50), Color.White);
            _spriteBatch.Draw(CookieSprite, new Vector2(Cookieposition.X - CookieRadius, Cookieposition.Y - CookieRadius), Color.White); 
            _spriteBatch.Draw(StoreSprite, new Vector2(1110, 0), Color.White);
            foreach (var component in _gameComponents)
                component.Draw(gameTime, _spriteBatch);
                _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
