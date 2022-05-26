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

        int Cookies = 0;
        int RebirthCookies = 0;

        int Booster = 1;
        int ClickUpgrade = 1;
        int Click = 2;
        int RebirthClick = 1;
        int CpsClick = 0;

        int RebirthCost = 1000000;

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

        int mouseClickerUpgradeCost2 = 2500;
        int cursorClickerUpgradeCost2 = 3750;
        int grandmaClickerUpgradeCost2 = 7500;
        int farmClickerUpgradeCost2 = 25000;
        int mineClickerUpgradeCost2 = 75000;
        int factoryClickerUpgradeCost2 = 1000000;
        int bankClickerUpgradeCost2 = 7500000;

        int CursorUpgrade = 1;
        int GrandmaUpgrade = 1;
        int FarmUpgrade = 1;
        int MineUpgrade = 1;
        int FactoryUpgrade = 1;
        int BankUpgrade = 1;

        Page ActivePage = Page.Store;

        int RebirthCursorAntal = 0;
        int RebirthGrandmaAntal = 0;
        int RebirthFarmAntal = 0;
        int RebirthMineAntal = 0;
        int RebirthFactoryAntal = 0;
        int RebirthBankAntal = 0;

        int RebirthCursorCps = 1;
        int RebirthGrandmaCps = 5;
        int RebirthFarmCps = 40;
        int RebirthMineCps = 125;
        int RebirthFactoryCps = 1000;
        int RebirthBankCps = 12000;

        int RebirthmouseClickerUpgradeCost = 500;
        int RebirthcursorClickerUpgradeCost = 750;
        int RebirthgrandmaClickerUpgradeCost = 1500;
        int RebirthfarmClickerUpgradeCost = 5000;
        int RebirthmineClickerUpgradeCost = 15000;
        int RebirthfactoryClickerUpgradeCost = 200000;
        int RebirthbankClickerUpgradeCost = 1500000;

        int RebirthCursorPerSec = 0;
        int RebirthGrandmaPerSec = 0;
        int RebirthFarmPerSec = 0;
        int RebirthMinePerSec = 0;
        int RebirthFactoryPerSec = 0;
        int RebirthBankPerSec = 0;

        decimal RebirthCursorCost = 100;
        decimal RebirthGrandmaCost = 250;
        decimal RebirthFarmCost = 1250;
        decimal RebirthMineCost = 10000;
        decimal RebirthFactoryCost = 100000;
        decimal RebirthBankCost = 850000;

        int RebirthCursorUpgrade = 1;
        int RebirthGrandmaUpgrade = 1;
        int RebirthFarmUpgrade = 1;
        int RebirthMineUpgrade = 1;
        int RebirthFactoryUpgrade = 1;
        int RebirthBankUpgrade = 1;


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
                Price = "Price:" + minifyLong((long)CursorCost)
            };
            
            cursorButton.click += CursorButton_click;

            var grandmaButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 475),
                Text = "  Grandma",
                Price = "Price:" + minifyLong((long)GrandmaCost)
            };

            grandmaButton.click += GrandmaButton_click;

           var farmButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 560),
                Text = "  Farm      ",
                Price = "Price:" + minifyLong((long)FarmCost)
            };

            farmButton.click += FarmButton_click1;

            var mineButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 645),
                Text = "  Mine       ",
                Price = "Price:" + minifyLong((long)MineCost)
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



            var RebirthcursorButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 390),
                Text = "  Cursor    ",
                Price = "Price:" + minifyLong((long)RebirthCursorCost)
            };

            RebirthcursorButton.click += RebirthcursorButton_click;

            var RebirthgrandmaButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 475),
                Text = "  Grandma",
                Price = "Price:" + minifyLong((long)RebirthGrandmaCost)
            };

            RebirthgrandmaButton.click += RebirthgrandmaButton_click;

            var RebirthfarmButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 560),
                Text = "  Farm      ",
                Price = "Price:" + minifyLong((long)RebirthFarmCost)
            };

            RebirthfarmButton.click += RebirthfarmButton_click;

            var RebirthmineButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 645),
                Text = "  Mine       ",
                Price = "Price:" + minifyLong((long)RebirthMineCost)
            };

            RebirthmineButton.click += RebirthmineButton_click;

            var RebirthfactoryButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 730),
                Text = "  Factory  ",
                Price = "Price:" + minifyLong((long)RebirthFactoryCost)
            };

            RebirthfactoryButton.click += RebirthfactoryButton_click;

            var RebirthbankButton = new Button(this, Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 815),
                Text = "  Bank      ",
                Price = "Price:" + minifyLong((long)RebirthBankCost)
            };

            RebirthbankButton.click += RebirthbankButton_click;

            var RebirthmouseclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 80),

            };

            RebirthmouseclickerButton.click += RebirthmouseclickerButton_click;

            var RebirthcursorclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1195, 80),

            };

            RebirthcursorclickerButton.click += RebirthcursorclickerButton_click;

            var RebirthgrandmaclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1275, 80),

            };

            RebirthgrandmaclickerButton.click += RebirthgrandmaclickerButton_click;

            var RebirthfarmclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1355, 80),

            };

            RebirthfarmclickerButton.click += RebirthfarmclickerButton_click;

            var RebirthmineclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1435, 80),

            };

            RebirthmineclickerButton.click += RebirthmineclickerButton_click;

            var RebirthfactoryclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1515, 80),

            };

            RebirthfactoryclickerButton.click += RebirthfactoryclickerButton_click;

            var RebirthbankclickerButton = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1115, 182),

            };

            RebirthbankclickerButton.click += RebirthbankclickerButton_click;

            var RebirthmouseclickerButton2 = new Button(this, Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/galleryFont"))
            {
                Position = new Vector2(1195, 182),

            };

            var RebirthButton = new Button(this, Content.Load<Texture2D>("Controls/Button4"), Content.Load<SpriteFont>("Fonts/galleryFontSmall"))
            {
                Position = new Vector2(1105, 335),
                Text = "                                                                                     Rebirth"

            };

            RebirthButton.click += RebirthButton_click;

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

            var RestartButton = new Button(this, Content.Load<Texture2D>("Controls/Button4"), Content.Load<SpriteFont>("Fonts/galleryFontSmall"))
            {
                Position = new Vector2(0, 850),
                Text = "                                                                                     Restart"

            };

            RestartButton.click += RestartButton_click;


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

               RestartButton,
            };

            _gameComponents2 = new List<MyComponent>()
            {

               RebirthmouseclickerButton,
               RebirthcursorclickerButton,
               RebirthgrandmaclickerButton,
               RebirthfarmclickerButton,
               RebirthmineclickerButton,
               RebirthfactoryclickerButton,
               RebirthbankclickerButton,

               RebirthcursorButton,
               RebirthgrandmaButton,
               RebirthfarmButton,
               RebirthmineButton,
               RebirthfactoryButton,
               RebirthbankButton,

               RebirthButton,

               Page1,
               Page2,

               RestartButton,
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

        private void RestartButton_click(object sender, System.EventArgs e)
        {

                Cookies = 0;
                RebirthCookies = 0;

                Booster = 1;
                ClickUpgrade = 1;
                Click = 2;
                RebirthClick = 1;
                CpsClick = 0;

                CursorPerSec = 0;
                GrandmaPerSec = 0;
                FarmPerSec = 0;
                MinePerSec = 0;
                FactoryPerSec = 0;
                BankPerSec = 0;

                CursorCost = 100;
                GrandmaCost = 250;
                FarmCost = 1250;
                MineCost = 10000;
                FactoryCost = 100000;
                BankCost = 850000;

                CursorAntal = 0;
                GrandmaAntal = 0;
                FarmAntal = 0;
                MineAntal = 0;
                FactoryAntal = 0;
                BankAntal = 0;

                CursorCps = 1;
                GrandmaCps = 5;
                FarmCps = 40;
                MineCps = 125;
                FactoryCps = 1000;
                BankCps = 12000;

                mouseClickerUpgradeCost = 500;
                cursorClickerUpgradeCost = 750;
                grandmaClickerUpgradeCost = 1500;
                farmClickerUpgradeCost = 5000;
                mineClickerUpgradeCost = 15000;
                factoryClickerUpgradeCost = 200000;
                bankClickerUpgradeCost = 1500000;

                mouseClickerUpgradeCost2 = 2500;
                cursorClickerUpgradeCost2 = 3750;
                grandmaClickerUpgradeCost2 = 7500;
                farmClickerUpgradeCost2 = 25000;
                mineClickerUpgradeCost2 = 75000;
                factoryClickerUpgradeCost2 = 1000000;
                bankClickerUpgradeCost2 = 7500000;

                CursorUpgrade = 1;
                GrandmaUpgrade = 1;
                FarmUpgrade = 1;
                MineUpgrade = 1;
                FactoryUpgrade = 1;
                BankUpgrade = 1;

                 RebirthCursorAntal = 0;
                 RebirthGrandmaAntal = 0;
                 RebirthFarmAntal = 0;
                 RebirthMineAntal = 0;
                 RebirthFactoryAntal = 0;
                 RebirthBankAntal = 0;

                 RebirthCursorCps = 1;
                 RebirthGrandmaCps = 5;
                 RebirthFarmCps = 40;
                 RebirthMineCps = 125;
                 RebirthFactoryCps = 1000;
                 RebirthBankCps = 12000;

                 RebirthmouseClickerUpgradeCost = 500;
                 RebirthcursorClickerUpgradeCost = 750;
                 RebirthgrandmaClickerUpgradeCost = 1500;
                 RebirthfarmClickerUpgradeCost = 5000;
                 RebirthmineClickerUpgradeCost = 15000;
                 RebirthfactoryClickerUpgradeCost = 200000;
                 RebirthbankClickerUpgradeCost = 1500000;

                 RebirthCursorPerSec = 0;
                 RebirthGrandmaPerSec = 0;
                 RebirthFarmPerSec = 0;
                 RebirthMinePerSec = 0;
                 RebirthFactoryPerSec = 0;
                 RebirthBankPerSec = 0;

                 RebirthCursorCost = 100;
                 RebirthGrandmaCost = 250;
                 RebirthFarmCost = 1250;
                 RebirthMineCost = 10000;
                 RebirthFactoryCost = 100000;
                 RebirthBankCost = 850000;

                 RebirthCursorUpgrade = 1;
                 RebirthGrandmaUpgrade = 1;
                 RebirthFarmUpgrade = 1;
                 RebirthMineUpgrade = 1;
                 RebirthFactoryUpgrade = 1;
                 RebirthBankUpgrade = 1;


        }

        private void RebirthButton_click(object sender, System.EventArgs e)
        {
            if (Cookies >= RebirthCost)
            {
                RebirthCookies += Cookies / 100;

                Cookies = 0;
                ClickUpgrade = 1;

                CursorPerSec = 0;
                GrandmaPerSec = 0;
                FarmPerSec = 0;
                MinePerSec = 0;
                FactoryPerSec = 0;
                BankPerSec = 0;

                CursorCost = 100;
                GrandmaCost = 250;
                FarmCost = 1250;
                MineCost = 10000;
                FactoryCost = 100000;
                BankCost = 850000;

                CursorAntal = 0;
                GrandmaAntal = 0;
                FarmAntal = 0;
                MineAntal = 0;
                FactoryAntal = 0;
                BankAntal = 0;

                CursorCps = 1;
                GrandmaCps = 5;
                FarmCps = 40;
                MineCps = 125;
                FactoryCps = 1000;
                BankCps = 12000;

                mouseClickerUpgradeCost = 500;
                cursorClickerUpgradeCost = 750;
                grandmaClickerUpgradeCost = 1500;
                farmClickerUpgradeCost = 5000;
                mineClickerUpgradeCost = 15000;
                factoryClickerUpgradeCost = 200000;
                bankClickerUpgradeCost = 1500000;

                mouseClickerUpgradeCost2 = 2500;
                cursorClickerUpgradeCost2 = 3750;
                grandmaClickerUpgradeCost2 = 7500;
                farmClickerUpgradeCost2 = 25000;
                mineClickerUpgradeCost2 = 75000;
                factoryClickerUpgradeCost2 = 1000000;
                bankClickerUpgradeCost2 = 7500000;

                CursorUpgrade = 1;
                GrandmaUpgrade = 1;
                FarmUpgrade = 1;
                MineUpgrade = 1;
                FactoryUpgrade = 1;
                BankUpgrade = 1;

            }
        }

        private void Page2_click(object sender, System.EventArgs e)
        {
            ActivePage = Page.RebirthStore;
        }

        private void Page1_click(object sender, System.EventArgs e)
        {
            ActivePage = Page.Store;
        }

        private void RebirthbankclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.RebirthStore)
            {
                if (RebirthCookies >= RebirthbankClickerUpgradeCost)
                {
                    RebirthBankUpgrade *= 2;
                    RebirthCookies -= RebirthbankClickerUpgradeCost;
                    RebirthBankCps *= 2;
                    RebirthbankClickerUpgradeCost *= 5;
                }
            }
        }

        private void RebirthfactoryclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.RebirthStore)
            {
                if (RebirthCookies >= RebirthfactoryClickerUpgradeCost)
                {
                    RebirthFactoryUpgrade *= 2;
                    RebirthCookies -= RebirthfactoryClickerUpgradeCost;
                    RebirthFactoryCps *= 2;
                    RebirthfactoryClickerUpgradeCost *= 5;
                }
            }
        }

        private void RebirthmineclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.RebirthStore)
            {
                if (RebirthCookies >= RebirthmineClickerUpgradeCost)
                {
                    RebirthMineUpgrade *= 2;
                    RebirthCookies -= RebirthmineClickerUpgradeCost;
                    RebirthMineCps *= 2;
                    RebirthmineClickerUpgradeCost *= 5;
                }
            }
        }

        private void RebirthfarmclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.RebirthStore)
            {
                if (RebirthCookies >= RebirthfarmClickerUpgradeCost)
                {
                    RebirthFarmUpgrade *= 2;
                    RebirthCookies -= RebirthfarmClickerUpgradeCost;
                    RebirthFarmCps *= 2;
                    RebirthfarmClickerUpgradeCost *= 5;
                }
            }
        }

        private void RebirthgrandmaclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.RebirthStore)
            {
                if (RebirthCookies >= RebirthgrandmaClickerUpgradeCost)
                {
                    RebirthGrandmaUpgrade *= 2;
                    RebirthCookies -= RebirthgrandmaClickerUpgradeCost;
                    RebirthGrandmaCps *= 2;
                    RebirthgrandmaClickerUpgradeCost *= 5;
                }
            }
        }

        private void RebirthcursorclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.RebirthStore)
            {
                if (RebirthCookies >= RebirthcursorClickerUpgradeCost)
                {
                    RebirthCursorUpgrade *= 2;
                    RebirthCookies -= RebirthcursorClickerUpgradeCost;
                    RebirthCursorCps *= 2;
                    RebirthcursorClickerUpgradeCost *= 5;
                }
            }
        }

        private void RebirthmouseclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.RebirthStore)
            {
                if (RebirthCookies >= RebirthmouseClickerUpgradeCost)
                {
                    RebirthClick *= 2;
                    RebirthCookies -= RebirthmouseClickerUpgradeCost;
                    RebirthmouseClickerUpgradeCost *= 5;
                }
            }
        }

        private void RebirthbankButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.RebirthStore)
            {
                if (RebirthCookies >= RebirthBankCost)
                {
                    RebirthCookies -= (int)RebirthBankCost;
                    RebirthBankPerSec += 12000;
                    RebirthBankCost *= NextPrice;
                    ((Button)sender).Price = "Price: " + (int)RebirthBankCost;
                    RebirthBankAntal += 1;
                }
            }
        }

        private void RebirthfactoryButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.RebirthStore)
            {
                if (RebirthCookies >= RebirthFactoryCost)
                {
                    RebirthCookies -= (int)RebirthFactoryCost;
                    RebirthFactoryPerSec += 1000;
                    RebirthFactoryCost *= NextPrice;
                    ((Button)sender).Price = "Price: " + (int)RebirthFactoryCost;
                    RebirthFactoryAntal += 1;
                }
            }
        }

        private void RebirthmineButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.RebirthStore)
            {
                if (RebirthCookies >= RebirthMineCost)
                {
                    RebirthCookies -= (int)RebirthMineCost;
                    RebirthMinePerSec += 40;
                    RebirthMineCost *= NextPrice;
                    ((Button)sender).Price = "Price: " + (int)RebirthMineCost;
                    RebirthMineAntal += 1;
                }
            }
        }

        private void RebirthfarmButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.RebirthStore)
            {
                if (RebirthCookies >= RebirthFarmCost)
                {
                    RebirthCookies -= (int)RebirthFarmCost;
                    RebirthFarmPerSec += 40;
                    RebirthFarmCost *= NextPrice;
                    ((Button)sender).Price = "Price: " + (int)RebirthFarmCost;
                    RebirthFarmAntal += 1;
                }
            }
        }

        private void RebirthgrandmaButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.RebirthStore)
            {
                if (RebirthCookies >= RebirthGrandmaCost)
                {

                    RebirthCookies -= (int)RebirthGrandmaCost;
                    RebirthGrandmaPerSec += 5;
                    RebirthGrandmaCost *= NextPrice;
                    ((Button)sender).Price = "Price: " + (int)RebirthGrandmaCost;
                    RebirthGrandmaAntal += 1;
                }
            }
        }

        private void RebirthcursorButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.RebirthStore)
            {
                if (RebirthCookies >= RebirthCursorCost)
                {
                    RebirthCookies -= (int)RebirthCursorCost;
                    RebirthCursorPerSec += 1;
                    RebirthCursorCost *= NextPrice;
                    ((Button)sender).Price = "Price: " + (int)RebirthCursorCost;
                    RebirthCursorAntal += 1;
                }
            }
        }



        private void BankclickerButton2_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= bankClickerUpgradeCost2)
                {
                    BankUpgrade *= 2;
                    Cookies -= bankClickerUpgradeCost2;
                    BankCps *= 2;
                    bankClickerUpgradeCost2 = 2000000000;

                }
            }
        }

        private void FactoryclickerButton2_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= factoryClickerUpgradeCost2)
                {
                    FactoryUpgrade *= 2;
                    Cookies -= factoryClickerUpgradeCost2;
                    FactoryCps *= 2;
                    factoryClickerUpgradeCost2 = 2000000000;
                }
            }
        }

        private void MineclickerButton2_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= mineClickerUpgradeCost2)
                {
                    MineUpgrade *= 2;
                    Cookies -= mineClickerUpgradeCost2;
                    MineCps *= 2;
                    mineClickerUpgradeCost2 = 2000000000;
                }
            }
        }

        private void FarmclickerButton2_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= farmClickerUpgradeCost2)
                {
                    FarmUpgrade *= 2;
                    Cookies -= farmClickerUpgradeCost2;
                    FarmCps *= 2;
                    farmClickerUpgradeCost2 = 2000000000;
                }
            }
        }

        private void GrandmaclickerButton2_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= grandmaClickerUpgradeCost2)
                {
                    GrandmaUpgrade *= 2;
                    Cookies -= grandmaClickerUpgradeCost2;
                    GrandmaCps *= 2;
                    grandmaClickerUpgradeCost2 = 2000000000;
                }
            }
        }

        private void CursorclickerButton2_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= cursorClickerUpgradeCost2)
                {
                    CursorUpgrade *= 2;
                    Cookies -= cursorClickerUpgradeCost2;
                    CursorCps *= 2;
                    cursorClickerUpgradeCost2 = 2000000000;
                }
            }
        }

        private void MouseclickerButton2_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= mouseClickerUpgradeCost2)
                {
                    ClickUpgrade *= 2;
                    Cookies -= mouseClickerUpgradeCost2;
                    mouseClickerUpgradeCost2 = 2000000000;
                }
            }
        }

        private void BankclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= bankClickerUpgradeCost)
                {
                    BankUpgrade *= 2;
                    Cookies -= bankClickerUpgradeCost;
                    BankCps *= 2;
                    bankClickerUpgradeCost = 2000000000;
                }
            }
        }

        private void FactoryclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= factoryClickerUpgradeCost)
                {
                    FactoryUpgrade *= 2;
                    Cookies -= factoryClickerUpgradeCost;
                    FactoryCps *= 2;
                    factoryClickerUpgradeCost = 2000000000;
                }
            }
        }

        private void MineclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= mineClickerUpgradeCost)
                {
                    MineUpgrade *= 2;
                    Cookies -= mineClickerUpgradeCost;
                    MineCps *= 2;
                    mineClickerUpgradeCost = 2000000000;
                }
            }
        }

        private void FarmclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= farmClickerUpgradeCost)
                {
                    FarmUpgrade *= 2;
                    Cookies -= farmClickerUpgradeCost;
                    FarmCps *= 2;
                    farmClickerUpgradeCost = 2000000000;
                }
            }
        }

        private void GrandmaclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= grandmaClickerUpgradeCost)
                {
                    GrandmaUpgrade *= 2;
                    Cookies -= grandmaClickerUpgradeCost;
                    GrandmaCps *= 2;
                    grandmaClickerUpgradeCost = 2000000000;
                }
            }
        }

        private void CursorclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= cursorClickerUpgradeCost)
                {
                    CursorUpgrade *= 2;
                    Cookies -= cursorClickerUpgradeCost;
                    CursorCps *= 2;
                    cursorClickerUpgradeCost = 2000000000;
                }
            }
        }

        private void MouseclickerButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
            {
                if (Cookies >= mouseClickerUpgradeCost)
                {
                    ClickUpgrade *= 2;
                    Cookies -= mouseClickerUpgradeCost;
                    mouseClickerUpgradeCost = 2000000000;
                }
            }
        }

        private void BankButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
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
        }

            private void FactoryButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
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
        }

        private void MineButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
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
        }

        private void FarmButton_click1(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
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
        }

        private void GrandmaButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
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
        }

        private void CursorButton_click(object sender, System.EventArgs e)
        {
            if (ActivePage == Page.Store)
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

        }


        protected override void Update(GameTime gameTime)
        {
            


            
            Click = 2 + (CursorPerSec * CursorUpgrade * RebirthCursorUpgrade + GrandmaPerSec * GrandmaUpgrade * RebirthGrandmaUpgrade + FarmPerSec * FarmUpgrade * RebirthFarmUpgrade + 
                MinePerSec * MineUpgrade * RebirthMineUpgrade + FactoryPerSec * FactoryUpgrade * RebirthFactoryUpgrade + BankPerSec * BankUpgrade * RebirthBankUpgrade + 
                RebirthCursorPerSec * RebirthCursorUpgrade * CursorUpgrade + RebirthGrandmaPerSec * RebirthGrandmaUpgrade * GrandmaUpgrade + RebirthFarmPerSec * RebirthFarmUpgrade * FarmUpgrade + 
                RebirthMinePerSec * RebirthMineUpgrade * MineUpgrade + RebirthFactoryPerSec * RebirthFactoryUpgrade * FactoryUpgrade + RebirthBankPerSec * RebirthBankUpgrade * BankUpgrade) / 1000; 
               
            secTimer += 1;
            if (secTimer == 60)
            {
                Cookies += CursorPerSec * CursorUpgrade * RebirthCursorUpgrade;
                Cookies += GrandmaPerSec * GrandmaUpgrade * RebirthGrandmaUpgrade;
                Cookies += FarmPerSec * FarmUpgrade * RebirthFarmUpgrade;
                Cookies += MinePerSec * MineUpgrade * RebirthMineUpgrade;
                Cookies += FactoryPerSec * FactoryUpgrade * RebirthFactoryUpgrade;
                Cookies += BankPerSec * BankUpgrade * RebirthBankUpgrade;

                Cookies += RebirthCursorPerSec * RebirthCursorUpgrade * CursorUpgrade;
                Cookies += RebirthGrandmaPerSec * RebirthGrandmaUpgrade * GrandmaUpgrade;
                Cookies += RebirthFarmPerSec * RebirthFarmUpgrade * FarmUpgrade;
                Cookies += RebirthMinePerSec * RebirthMineUpgrade * MineUpgrade;
                Cookies += RebirthFactoryPerSec * RebirthFactoryUpgrade * FactoryUpgrade;
                Cookies += RebirthBankPerSec * RebirthBankUpgrade * BankUpgrade;
                CpsClick = 0;
                secTimer = 0;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mState = Mouse.GetState();

            if (mState.LeftButton == ButtonState.Released)
            {
                mReleased = true;

            }


            if (CpsClick >= 10)
            {
                Booster = 5;
            }

            else if (CpsClick >= 5 && CpsClick <=9)
            {
                Booster = 3;
            }

            else if (CpsClick >= 2 && CpsClick <= 4)
            {
                Booster = 2;
            }
            
            else if (CpsClick < 2)
            {
                Booster = 1;
            }
            

            if (mState.LeftButton == ButtonState.Pressed && mReleased == true)
            {
                float mouseCookieDist = Vector2.Distance(Cookieposition, mState.Position.ToVector2());
                if(mouseCookieDist < CookieRadius)
                {
                    
                    Cookies += Click * ClickUpgrade * RebirthClick * Booster;
                    CpsClick += 1;
                }
                mReleased = false;
            }





            foreach (var component in _gameComponents)
                component.Update(gameTime);

            foreach (var component in _gameComponents2)
                component.Update(gameTime);


            base.Update(gameTime);
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
                return (value / 1000000).ToString() + "M";
            else if (value >= 100000)
                return (value / 1000).ToString() + "K";
            else if (value >= 10000)
                return (value / 1000).ToString() + "K";
            string t = value.ToString();
            return t;
        }


        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(BackgroundSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(gameFont, "Cookies:" + " " + minifyLong(Cookies), new Vector2(50, 50), Color.White);
            _spriteBatch.DrawString(gameFont, "Rebirth Cookies:" + " " + minifyLong(RebirthCookies), new Vector2(50, 800), Color.White);
            _spriteBatch.DrawString(gameFontSmall, "Cookies per Click:" + " " + minifyLong(Click * ClickUpgrade * RebirthClick * Booster), new Vector2(860, 100), Color.White);
            _spriteBatch.DrawString(gameFontSmall, "Cookies per click recieves a bonus", new Vector2(800, 30), Color.White);
            _spriteBatch.DrawString(gameFontSmall, "from the total Cps by 0.001%", new Vector2(820, 55), Color.White);
            _spriteBatch.Draw(CookieSprite, new Vector2(Cookieposition.X - CookieRadius, Cookieposition.Y - CookieRadius), Color.White);
     

            if (ActivePage == Page.Store)
            {
                _spriteBatch.Draw(StoreSprite, new Vector2(1110, 0), Color.White);


                _spriteBatch.DrawString(gameFontSmall, minifyLong(500), new Vector2(1135, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(750), new Vector2(1210, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(1500), new Vector2(1288, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(5000), new Vector2(1369, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(15000), new Vector2(1452, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(200000), new Vector2(1528, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(1500000), new Vector2(1124, 260), Color.White);

                _spriteBatch.DrawString(gameFontSmall, minifyLong(2500), new Vector2(1210, 260), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(3750), new Vector2(1287, 260), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(7500), new Vector2(1370, 260), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(25000), new Vector2(1455, 260), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(75000), new Vector2(1531, 260), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(1000000), new Vector2(1125, 360), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(7500000), new Vector2(1208, 360), Color.White);

                _spriteBatch.DrawString(gameFontSmall, "Doubles income from sources", new Vector2(1310, 310), Color.White);
                _spriteBatch.DrawString(gameFontSmall, "**Can only be upgraded once**", new Vector2(1300, 350), Color.White);


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

                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(CursorCps * RebirthCursorUpgrade) + " Cps", new Vector2(1260, 400), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(GrandmaCps * RebirthGrandmaUpgrade) + " Cps", new Vector2(1290, 485), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(FarmCps * RebirthFarmUpgrade) + " Cps", new Vector2(1230, 570), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(MineCps * RebirthMineUpgrade) + " Cps", new Vector2(1230, 655), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(FactoryCps * RebirthFactoryUpgrade) + " Cps", new Vector2(1250, 740), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(BankCps * RebirthBankUpgrade) + " Cps", new Vector2(1240, 825), Color.Black);
            }

            else if (ActivePage == Page.RebirthStore)
            {
                _spriteBatch.Draw(StoreSprite, new Vector2(1110, 0), Color.White);
                foreach (var component in _gameComponents2)
                    component.Draw(gameTime, _spriteBatch);

                _spriteBatch.Draw(MouseClickerSprite, new Vector2(1105, 68), Color.White);
                _spriteBatch.Draw(CursorClickerSprite, new Vector2(1182, 68), Color.White);
                _spriteBatch.Draw(GrandmaClickerSprite, new Vector2(1266, 50), Color.White);
                _spriteBatch.Draw(FarmClickerSprite, new Vector2(1343, 68), Color.White);
                _spriteBatch.Draw(MineClickerSprite, new Vector2(1422, 68), Color.White);
                _spriteBatch.Draw(FactoryClickerSprite, new Vector2(1502, 68), Color.White);
                _spriteBatch.Draw(BankClickerSprite, new Vector2(1103, 167), Color.White);

                _spriteBatch.DrawString(gameFontSmall, minifyLong(RebirthmouseClickerUpgradeCost), new Vector2(1135, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(RebirthcursorClickerUpgradeCost), new Vector2(1210, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(RebirthgrandmaClickerUpgradeCost), new Vector2(1288, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(RebirthfarmClickerUpgradeCost), new Vector2(1369, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(RebirthmineClickerUpgradeCost), new Vector2(1452, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(RebirthfactoryClickerUpgradeCost), new Vector2(1528, 160), Color.White);
                _spriteBatch.DrawString(gameFontSmall, minifyLong(RebirthbankClickerUpgradeCost), new Vector2(1124, 260), Color.White);

                _spriteBatch.DrawString(gameFontSmall, "Doubles income from sources", new Vector2(1260, 200), Color.White);
                _spriteBatch.DrawString(gameFontSmall, "**Upgrades stays after Rebirth**", new Vector2(1250, 230), Color.White);
                _spriteBatch.DrawString(gameFontSmall, "Rebirthing will reset your progress", new Vector2(1285, 270), Color.White);
                _spriteBatch.DrawString(gameFontSmall, "and give you Rebirth cookies", new Vector2(1305, 295), Color.White);
                _spriteBatch.DrawString(gameFontSmall, "based on your amount of cookies", new Vector2(1285, 320), Color.White);
                _spriteBatch.DrawString(gameFontSmall, "Ratio", new Vector2(1170, 290), Color.White);
                _spriteBatch.DrawString(gameFontSmall, "100 : 1", new Vector2(1160, 315), Color.White);
                _spriteBatch.DrawString(gameFontSmall, "Min Requirement = 1000K Cookies", new Vector2(1280, 350), Color.White);


                _spriteBatch.Draw(CursorClickerSprite, new Vector2(1100, 378), Color.White);
                _spriteBatch.Draw(GrandmaClickerSprite, new Vector2(1110, 444), Color.White);
                _spriteBatch.Draw(FarmClickerSprite, new Vector2(1105, 550), Color.White);
                _spriteBatch.Draw(MineClickerSprite, new Vector2(1105, 632), Color.White);
                _spriteBatch.Draw(FactoryClickerSprite, new Vector2(1105, 718), Color.White);
                _spriteBatch.Draw(BankClickerSprite, new Vector2(1105, 802), Color.White);

                _spriteBatch.DrawString(gameFontSmall, " " + RebirthCursorAntal.ToString(), new Vector2(1370, 418), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, " " + RebirthGrandmaAntal.ToString(), new Vector2(1370, 503), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, " " + RebirthFarmAntal.ToString(), new Vector2(1370, 588), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, " " + RebirthMineAntal.ToString(), new Vector2(1370, 673), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, " " + RebirthFactoryAntal.ToString(), new Vector2(1370, 758), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, " " + RebirthBankAntal.ToString(), new Vector2(1370, 843), Color.Black);

                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(RebirthCursorCps * CursorUpgrade) + " Cps", new Vector2(1260, 400), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(RebirthGrandmaCps * GrandmaUpgrade) + " Cps", new Vector2(1290, 485), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(RebirthFarmCps * FarmUpgrade) + " Cps", new Vector2(1230, 570), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(RebirthMineCps * MineUpgrade) + " Cps", new Vector2(1230, 655), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(RebirthFactoryCps * FactoryUpgrade) + " Cps", new Vector2(1250, 740), Color.Black);
                _spriteBatch.DrawString(gameFontSmall, "+ " + minifyLong(RebirthBankCps * BankUpgrade) + " Cps", new Vector2(1240, 825), Color.Black);
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}