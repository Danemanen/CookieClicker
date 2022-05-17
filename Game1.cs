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

        Texture2D MouseClickerSprite;
        Texture2D CursorClickerSprite;
        Texture2D GrandmaClickerSprite;
        Texture2D FarmClickerSprite;
        Texture2D MineClickerSprite;
        Texture2D FactoryClickerSprite;
        Texture2D BankClickerSprite;
        Texture2D CookieSprite;
        Texture2D BackgroundSprite;
        Texture2D StoreSprite;
        SpriteFont gameFont;
        SpriteFont gameFontSmall;

        Vector2 Cookieposition = new Vector2(420, 450);
        const int CookieRadius = 300;
        
        MouseState mState;
        bool mReleased = true;

        int Cookies = 10000;

        int Click = 1;

        int CursorPerSec = 0;
        int GrandmaPerSec = 0;
        int FarmPerSec = 0;
        int MinePerSec = 0;
        int FactoryPerSec = 0;
        int BankPerSec = 0;

        decimal CursorCost = 100;
        decimal GrandmaCost = 250;
        decimal FarmCost = 1250;
        decimal MineCost = 10000;
        decimal FactoryCost = 100000;
        decimal BankCost = 850000;

        int secTimer = 0;

        int mouseClickerUpgradeCost = 500;
        int cursorClickerUpgradeCost = 750;
        int grandmaClickerUpgradeCost = 1500;
        int farmClickerUpgradeCost = 5000;
        int mineClickerUpgradeCost = 15000;
        int factoryClickerUpgradeCost = 200000;
        int bankClickerUpgradeCost = 1500000;

        decimal NextPrice = 1.2m;

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
                Position = new Vector2(1115, 390),
                Text = "Cursor    ",
                Price = "Price:" + CursorCost,
            };
            
            cursorButton.click += CursorButton_click;

            var grandmaButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 475),
                Text = "Grandma",
                Price = "Price:" + GrandmaCost,
            };

            grandmaButton.click += GrandmaButton_click;

            var farmButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 560),
                Text = "Farm      ",
                Price = "Price:" + FarmCost,
            };

            farmButton.click += FarmButton_click;

            var mineButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 645),
                Text = "Mine       ",
                Price = "Price:" + MineCost,
            };

            mineButton.click += MineButton_click;

            var factoryButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 730),
                Text = "Factory  ",
                Price = "Price:" + FactoryCost,
            };

            factoryButton.click += FactoryButton_click;

            var bankButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 815),
                Text = "Bank      ",
                Price = "Price:" + BankCost,
            };

            var mouseclickerButton = new Button(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 80),
             
            };

            var cursorclickerButton = new Button(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1195, 80),

            };

            var grandmaclickerButton = new Button(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1275, 80),

            };

            var farmclickerButton = new Button(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1355, 80),

            };

            var mineclickerButton = new Button(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1435, 80),

            };

            var factoryclickerButton = new Button(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1515, 80),

            };

            var bankclickerButton = new Button(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 200),

            };



            bankButton.click += BankButton_click;

            _gameComponents = new List<MyComponent>()
            {
               mouseclickerButton,
               cursorclickerButton,
               grandmaclickerButton,
               farmclickerButton,
               mineclickerButton,
               factoryclickerButton,
               bankclickerButton,
               cursorButton,
               grandmaButton,
               farmButton,
               mineButton,
               factoryButton,
               bankButton,
            };

            StoreSprite = Content.Load<Texture2D>("Store");
            CookieSprite = Content.Load<Texture2D>("Cookie");
            BackgroundSprite = Content.Load<Texture2D>("Background");
            MouseClickerSprite = Content.Load<Texture2D>("mouseclicker");
            CursorClickerSprite = Content.Load<Texture2D>("cursorclicker");
            gameFont = Content.Load<SpriteFont>("Fonts/galleryFont");
            gameFontSmall = Content.Load<SpriteFont>("Fonts/galleryFontSmall");


        }

        private void BankButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= BankCost)
            {
                Cookies -= (int)BankCost;
                BankPerSec += 12000;
                BankCost *= NextPrice;
            }
        }

        private void FactoryButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= FactoryCost)
            {
                Cookies -= (int)FactoryCost;
                FactoryPerSec += 1000;
                FactoryCost *= NextPrice;
            }
        }

        private void MineButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= MineCost)
            {
                Cookies -= (int)MineCost;
                MinePerSec += 125;
                MineCost *= NextPrice;
            }
        }

        private void FarmButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= FarmCost)
            {
                Cookies -= (int)FarmCost;
                FarmPerSec += 40;
                FarmCost *= NextPrice;
            }
        }

        private void GrandmaButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= GrandmaCost)
            {
                Cookies -= (int)GrandmaCost;
                GrandmaPerSec += 5;
                GrandmaCost *= NextPrice;
            }
        }

        private void CursorButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= CursorCost)
            {
                Cookies -= (int)CursorCost;
                CursorPerSec += 1;
                
                CursorCost *= NextPrice;
               
            }
        }

        protected override void Update(GameTime gameTime)
        {
            secTimer += 1;
            if (secTimer == 60)
            {
                Cookies += GrandmaPerSec;
                Cookies += CursorPerSec;
                Cookies += FarmPerSec;
                Cookies += MinePerSec;
                Cookies += FactoryPerSec;
                Cookies += BankPerSec;
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
            _spriteBatch.Draw(MouseClickerSprite, new Vector2(1110, 0), Color.White);
            _spriteBatch.DrawString(gameFontSmall, " " + mouseClickerUpgradeCost, new Vector2(1130, 160), Color.White);
            foreach (var component in _gameComponents)
                component.Draw(gameTime, _spriteBatch);
                _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}