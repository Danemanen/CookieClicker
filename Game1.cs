using CookieClicker.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CookieClicker
{
    public enum Page
    {
        Store, RebirthStore
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<MyComponent> _gameComponents;
        private List<MyComponent> _gameComponents2;


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
        int RebirthCookies = 0;

        int Click = 2;

        int secTimer = 0;

        decimal NextPrice = 1.15m;

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

        int CursorAntal = 0;
        int GrandmaAntal = 0;
        int FarmAntal = 0;
        int MineAntal = 0;
        int FactoryAntal = 0;
        int BankAntal = 0;

        int CursorCps = 1;
        int GrandmaCps = 5;
        int FarmCps = 40;
        int MineCps = 125;
        int FactoryCps = 1000;
        int BankCps = 12000;

        int mouseClickerUpgradeCost = 500;
        int cursorClickerUpgradeCost = 750;
        int grandmaClickerUpgradeCost = 1500;
        int farmClickerUpgradeCost = 5000;
        int mineClickerUpgradeCost = 15000;
        int factoryClickerUpgradeCost = 200000;
        int bankClickerUpgradeCost = 1500000;

        int CursorUpgrade = 1;
        int GrandmaUpgrade = 1;
        int FarmUpgrade = 1;
        int MineUpgrade = 1;
        int FactoryUpgrade = 1;
        int BankUpgrade = 1;
        Page ActivePage = Page.Store;

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

            var cursorButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 390),
                Text = "  Cursor    ",
                Price = "Price:" + CursorCost,
            };
            
            cursorButton.click += CursorButton_click;

            var grandmaButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 475),
                Text = "  Grandma",
                Price = "Price:" + GrandmaCost,
            };

            grandmaButton.click += GrandmaButton_click;

           var farmButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 560),
                Text = "  Farm      ",
                Price = "Price:" + FarmCost,
            };

            farmButton.click += FarmButton_click1;

            var mineButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 645),
                Text = "  Mine       ",
                Price = "Price:" + MineCost,
            };

            mineButton.click += MineButton_click;

            var factoryButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 730),
                Text = "  Factory  ",
                Price = "Price:" + minifyLong((long)FactoryCost)
            };

            factoryButton.click += FactoryButton_click;

            var bankButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 815),
                Text = "  Bank      ",
                Price = "Price:" + minifyLong((long)BankCost)
            };

            bankButton.click += BankButton_click;
            
            var mouseclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 80),
             
            };

            mouseclickerButton.click += MouseclickerButton_click;

            var cursorclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1195, 80),

            };

            cursorclickerButton.click += CursorclickerButton_click;

            var grandmaclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1275, 80),

            };

            grandmaclickerButton.click += GrandmaclickerButton_click;

            var farmclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1355, 80),

            };

            farmclickerButton.click += FarmclickerButton_click;

            var mineclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1435, 80),

            };

            mineclickerButton.click += MineclickerButton_click;

            var factoryclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1515, 80),

            };

            factoryclickerButton.click += FactoryclickerButton_click;

            var bankclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 182),

            };

            bankclickerButton.click += BankclickerButton_click;

            var mouseclickerButton2 = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1195, 182),

            };

            mouseclickerButton2.click += MouseclickerButton2_click;

            var cursorclickerButton2 = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1275, 182),

            };

            cursorclickerButton2.click += CursorclickerButton2_click;

            var grandmaclickerButton2 = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1355, 182),

            };

            grandmaclickerButton2.click += GrandmaclickerButton2_click;

            var farmclickerButton2 = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1435, 182),

            };

            farmclickerButton2.click += FarmclickerButton2_click;

            var mineclickerButton2 = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1515, 182),

            };

            mineclickerButton2.click += MineclickerButton2_click;

            var factoryclickerButton2 = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 282),

            };

            factoryclickerButton2.click += FactoryclickerButton2_click;

            var bankclickerButton2 = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1195, 282),

            };

            bankclickerButton2.click += BankclickerButton2_click;

            var Page1 = new Button(this, Content.Load<Texture2D>("Controls/Button4"), Content.Load<SpriteFont>("Fonts/galleryFontSmall"))
            {
                Position = new Vector2(900, 800),
                Text = "                                                                                     Page 1",
            };

            Page1.click += Page1_click;

            var Page2 = new Button(this, Content.Load<Texture2D>("Controls/Button4"), Content.Load<SpriteFont>("Fonts/galleryFontSmall"))
            {
                Position = new Vector2(900, 850),
                Text = "                                                                                     Page 2",
            };

            Page2.click += Page2_click;


            _gameComponents = new List<MyComponent>()
            {
               mouseclickerButton,
               cursorclickerButton,
               grandmaclickerButton,
               farmclickerButton,
               mineclickerButton,
               factoryclickerButton,
               bankclickerButton,

               mouseclickerButton2,
               cursorclickerButton2,
               grandmaclickerButton2,
               farmclickerButton2,
               mineclickerButton2,
               factoryclickerButton2,
               bankclickerButton2,

               cursorButton,
               grandmaButton,
               farmButton,
               mineButton,
               factoryButton,
               bankButton,

               Page1,
               Page2,
            };

            _gameComponents2 = new List<MyComponent>()
            {
                Page1,Page2
            };

            StoreSprite = Content.Load<Texture2D>("Store");
            CookieSprite = Content.Load<Texture2D>("Cookie");
            BackgroundSprite = Content.Load<Texture2D>("Background");
            MouseClickerSprite = Content.Load<Texture2D>("mouseclicker");
            CursorClickerSprite = Content.Load<Texture2D>("cursorclicker");
            GrandmaClickerSprite = Content.Load<Texture2D>("grandmaclicker");
            FarmClickerSprite = Content.Load<Texture2D>("farmclicker");
            MineClickerSprite = Content.Load<Texture2D>("mineclicker");
            FactoryClickerSprite = Content.Load<Texture2D>("fatoryclicker");
            BankClickerSprite = Content.Load<Texture2D>("bankclicker");
            gameFont = Content.Load<SpriteFont>("Fonts/galleryFont");
            gameFontSmall = Content.Load<SpriteFont>("Fonts/galleryFontSmall");


        }

        private void Page2_click(object sender, System.EventArgs e)
        {
            ActivePage = Page.RebirthStore;
        }

        private void Page1_click(object sender, System.EventArgs e)
        {
            ActivePage = Page.Store;
        }

        private void BankclickerButton2_click(object sender, System.EventArgs e)
        {
            if (Cookies >= bankClickerUpgradeCost * 5)
            {
                BankUpgrade *= 2;
                Cookies -= bankClickerUpgradeCost * 5;
                BankCps *= 2;
            }
        }

        private void FactoryclickerButton2_click(object sender, System.EventArgs e)
        {
            if (Cookies >= factoryClickerUpgradeCost * 5)
            {
                FactoryUpgrade *= 2;
                Cookies -= factoryClickerUpgradeCost * 5;
                FactoryCps *= 2;
            }
        }

        private void MineclickerButton2_click(object sender, System.EventArgs e)
        {
            if (Cookies >= mineClickerUpgradeCost * 5)
            {
                MineUpgrade *= 2;
                Cookies -= mineClickerUpgradeCost * 5;
                MineCps *= 2;
            }
        }

        private void FarmclickerButton2_click(object sender, System.EventArgs e)
        {
            if (Cookies >= farmClickerUpgradeCost * 5)
            {
                FarmUpgrade *= 2;
                Cookies -= farmClickerUpgradeCost * 5;
                FarmCps *= 2;
            }
        }

        private void GrandmaclickerButton2_click(object sender, System.EventArgs e)
        {
            if (Cookies >= grandmaClickerUpgradeCost * 5)
            {
                GrandmaUpgrade *= 2;
                Cookies -= grandmaClickerUpgradeCost * 5;
                GrandmaCps *= 2;
            }
        }

        private void CursorclickerButton2_click(object sender, System.EventArgs e)
        {
            if (Cookies >= cursorClickerUpgradeCost * 5)
            {
                CursorUpgrade *= 2;
                Cookies -= cursorClickerUpgradeCost * 5;
                CursorCps *= 2;
            }
        }

        private void MouseclickerButton2_click(object sender, System.EventArgs e)
        {
            if (Cookies >= mouseClickerUpgradeCost * 5)
            {
                Click *= 2;
                Cookies -= mouseClickerUpgradeCost * 5;

            }
        }

        private void BankclickerButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= bankClickerUpgradeCost)
            {
                BankUpgrade *= 2;
                Cookies -= bankClickerUpgradeCost;
                BankCps *= 2;
            }
        }

        private void FactoryclickerButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= factoryClickerUpgradeCost)
            {
                FactoryUpgrade *= 2;
                Cookies -= factoryClickerUpgradeCost;
                FactoryCps *= 2;
            }
        }

        private void MineclickerButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= mineClickerUpgradeCost)
            {
                MineUpgrade *= 2;
                Cookies -= mineClickerUpgradeCost;
                MineCps *= 2;
            }
        }

        private void FarmclickerButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= farmClickerUpgradeCost)
            {
                FarmUpgrade *= 2;
                Cookies -= farmClickerUpgradeCost;
                FarmCps *= 2;
            }
        }

        private void GrandmaclickerButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= grandmaClickerUpgradeCost)
            {
                GrandmaUpgrade *= 2;
                Cookies -= grandmaClickerUpgradeCost;
                GrandmaCps *= 2;
            }
        }

        private void CursorclickerButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= cursorClickerUpgradeCost)
            {
                CursorUpgrade *= 2;
                Cookies -= cursorClickerUpgradeCost;
                CursorCps *= 2;
            }
        }

        private void MouseclickerButton_click(object sender, System.EventArgs e)
        {
            
            if (Cookies >= mouseClickerUpgradeCost)
            {
                Click *= 2;
                Cookies -= mouseClickerUpgradeCost;
            }
        }

        private void BankButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= BankCost)
            {
                Cookies -= (int)BankCost;
                BankPerSec += 12000;
                BankCost *= NextPrice;
                ((Button)sender).Price = "Price: " + (int)BankCost;
                BankAntal += 1;
            }
        }

        private void FactoryButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= FactoryCost)
            {
                Cookies -= (int)FactoryCost;
                FactoryPerSec += 1000;
                FactoryCost *= NextPrice;
                ((Button)sender).Price = "Price: " + (int)FactoryCost;
                FactoryAntal += 1;
            }
        }

        private void MineButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= MineCost)
            {
                Cookies -= (int)MineCost;
                MinePerSec += 125;
                MineCost *= NextPrice;
                ((Button)sender).Price = "Price: " + (int)MineCost;
                MineAntal += 1;
            }
        }

        private void FarmButton_click1(object sender, System.EventArgs e)
        {
            if (Cookies >= FarmCost)
            {
                Cookies -= (int)FarmCost;
                FarmPerSec += 40;
                FarmCost *= NextPrice;
                ((Button)sender).Price = "Price: " + (int)FarmCost;
                FarmAntal += 1;
            }
        }

        private void GrandmaButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= GrandmaCost)
            {
                
                Cookies -= (int)GrandmaCost;
                GrandmaPerSec += 5;
                GrandmaCost = GrandmaCost *= NextPrice;
                ((Button)sender).Price = "Price: " + (int)GrandmaCost;
                GrandmaAntal += 1;
            }
        }

        private void CursorButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= CursorCost)
            {
                Cookies -= (int)CursorCost;
                CursorPerSec += 1;
                CursorCost *= NextPrice;
                ((Button)sender).Price = "Price: " + (int)CursorCost;
                CursorAntal += 1;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            secTimer += 1;
            if (secTimer == 60)
            {
                Cookies += CursorPerSec * CursorUpgrade;
                Cookies += GrandmaPerSec * GrandmaUpgrade;
                Cookies += FarmPerSec * FarmUpgrade;
                Cookies += MinePerSec * MineUpgrade;
                Cookies += FactoryPerSec * FactoryUpgrade;
                Cookies += BankPerSec * BankUpgrade;
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
            _spriteBatch.DrawString(gameFont, "Cookies:" + " " + minifyLong(Cookies), new Vector2(50, 50), Color.White);
            _spriteBatch.DrawString(gameFont, "Rebirth Cookies:" + " " + minifyLong(RebirthCookies), new Vector2(50, 800), Color.White);
            _spriteBatch.Draw(CookieSprite, new Vector2(Cookieposition.X - CookieRadius, Cookieposition.Y - CookieRadius), Color.White);
     

            if (ActivePage == Page.Store)
            {
                _spriteBatch.Draw(StoreSprite, new Vector2(1110, 0), Color.White);


                _spriteBatch.DrawString(gameFontSmall, minifyLong(mouseClickerUpgradeCost), new Vector2(1130, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(cursorClickerUpgradeCost), new Vector2(1210, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(grandmaClickerUpgradeCost), new Vector2(1282, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(farmClickerUpgradeCost), new Vector2(1365, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(mineClickerUpgradeCost), new Vector2(1437, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(factoryClickerUpgradeCost), new Vector2(1515, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(bankClickerUpgradeCost), new Vector2(1110, 260), Color.White);

                _spriteBatch.DrawString(gameFontSmall, minifyLong(mouseClickerUpgradeCost * 5), new Vector2(1207, 260), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(cursorClickerUpgradeCost * 5), new Vector2(1282, 260), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(grandmaClickerUpgradeCost * 5), new Vector2(1365, 260), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(farmClickerUpgradeCost * 5), new Vector2(1438, 260), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(mineClickerUpgradeCost * 5), new Vector2(1518, 260), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(factoryClickerUpgradeCost * 5), new Vector2(1110, 360), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(bankClickerUpgradeCost * 5), new Vector2(1190, 360), Color.White);

                _spriteBatch.DrawString(gameFontSmall, "Doubles income from sources", new Vector2(1300, 320), Color.White);


                foreach (var component in _gameComponents)
                    component.Draw(gameTime, _spriteBatch);


                _spriteBatch.Draw(MouseClickerSprite, new Vector2(1105, 68), Color.White);
                _spriteBatch.Draw(CursorClickerSprite, new Vector2(1182, 68), Color.White);
                _spriteBatch.Draw(GrandmaClickerSprite, new Vector2(1266, 50), Color.White);
                _spriteBatch.Draw(FarmClickerSprite, new Vector2(1343, 68), Color.White);
                _spriteBatch.Draw(MineClickerSprite, new Vector2(1422, 68), Color.White);
                _spriteBatch.Draw(FactoryClickerSprite, new Vector2(1502, 68), Color.White);
                _spriteBatch.Draw(BankClickerSprite, new Vector2(1103, 167), Color.White);

                _spriteBatch.Draw(MouseClickerSprite, new Vector2(1185, 169), Color.White);
                _spriteBatch.Draw(CursorClickerSprite, new Vector2(1262, 170), Color.White);
                _spriteBatch.Draw(GrandmaClickerSprite, new Vector2(1347, 152), Color.White);
                _spriteBatch.Draw(FarmClickerSprite, new Vector2(1422, 170), Color.White);
                _spriteBatch.Draw(MineClickerSprite, new Vector2(1501, 168), Color.White);
                _spriteBatch.Draw(FactoryClickerSprite, new Vector2(1102, 268), Color.White);
                _spriteBatch.Draw(BankClickerSprite, new Vector2(1183, 267), Color.White);

                _spriteBatch.Draw(CursorClickerSprite, new Vector2(1100, 378), Color.White);
                _spriteBatch.Draw(GrandmaClickerSprite, new Vector2(1110, 444), Color.White);
                _spriteBatch.Draw(FarmClickerSprite, new Vector2(1105, 550), Color.White);
                _spriteBatch.Draw(MineClickerSprite, new Vector2(1105, 632), Color.White);
                _spriteBatch.Draw(FactoryClickerSprite, new Vector2(1105, 718), Color.White);
                _spriteBatch.Draw(BankClickerSprite, new Vector2(1105, 802), Color.White);

                _spriteBatch.DrawString(gameFontSmall, " " + CursorAntal.ToString(), new Vector2(1370, 418), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, " " + GrandmaAntal.ToString(), new Vector2(1370, 503), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, " " + FarmAntal.ToString(), new Vector2(1370, 588), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, " " + MineAntal.ToString(), new Vector2(1370, 673), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, " " + FactoryAntal.ToString(), new Vector2(1370, 758), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, " " + BankAntal.ToString(), new Vector2(1370, 843), Color.Black);

                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(CursorCps) + " Cps", new Vector2(1260, 400), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(GrandmaCps) + " Cps", new Vector2(1290, 485), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(FarmCps) + " Cps", new Vector2(1230, 570), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(MineCps) + " Cps", new Vector2(1230, 655), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(FactoryCps) + " Cps", new Vector2(1250, 740), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(BankCps) + " Cps", new Vector2(1240, 825), Color.Black);
            }
            else if(ActivePage==Page.RebirthStore)
            {
                _spriteBatch.Draw(StoreSprite, new Vector2(1110, 0), Color.White);
                foreach (var component in _gameComponents2)
                    component.Draw(gameTime, _spriteBatch);
            }
            

            _spriteBatch.End();
            base.Draw(gameTime);
        }
        public string minifyLong(long value)
        {
            if (value >= 100000000000)
                return (value / 1000000000).ToString() + "B";
            else if (value >= 10000000000)
                return (value / 1000000000).ToString() + "B";
            else if (value >= 100000000)
                return (value / 1000000).ToString() + "M";
            else if (value >= 10000000)
                return (value / 100000).ToString() + "M";
            else if (value >= 100000)
                return (value / 1000).ToString() + "K";
            else if (value >= 10000)
                return (value / 1000).ToString() + "K";
            string t = value.ToString();
            return t;
        }
        //public string minifyLong(long value)
        //{
        //    return value + "";
        //}
    }
}