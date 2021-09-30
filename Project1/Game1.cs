﻿using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Commands;
using Project1.Controllers;
using Project1.Enemy;
using Project1.NPC;
using Project1.Interfaces;
using Project1.Sprites;
using Project1.Objects;

namespace Project1
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // Game Objects
        public Player link;
        public CyclableBlock cyclableBlock;
        public CyclableItem cyclableItem;
        public CyclableEnemy cyclableEnemy;
       
        private Vector2 position;
        private Vector2 enemyPosition;

        private ArrayList controllerList;
        private List<IEnemy> enemyList;

        private SpriteFont font;

        private Viewport ViewPort => graphics.GraphicsDevice.Viewport;
        public int SCREEN_WIDTH => ViewPort.Width;
        public int SCREEN_HEIGHT => ViewPort.Height;

        public Texture2D spriteSheet;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            position = new Vector2(SCREEN_WIDTH / 2, SCREEN_HEIGHT / 2);
            enemyPosition = new Vector2(SCREEN_WIDTH / 4 * 3, SCREEN_HEIGHT / 4 * 3);
            controllerList = new ArrayList
            {
                new KeyboardController(this),
                new MouseController(this)
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteSheet = Content.Load<Texture2D>("smb_enemies_sheet");
            font = Content.Load<SpriteFont>("Name");
            SpriteFactory.Instance.LoadAllTextures(Content);

            link = new Player(position, spriteBatch);
            enemyList = new List<IEnemy> { new Stalfos(enemyPosition), new RedGloriya(enemyPosition), 
                        new BlueGel(enemyPosition), new BlueBat(enemyPosition), new Aquamentus(enemyPosition),
                        new OldMan(enemyPosition)};
           
            cyclableEnemy = new CyclableEnemy(enemyList);
            cyclableBlock = new CyclableBlock();
            cyclableItem = new CyclableItem();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            link.Update();

            cyclableBlock.Update();
            cyclableItem.Update();
          
            cyclableEnemy.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            link.Draw();
           
            cyclableEnemy.Draw(spriteBatch);
            cyclableBlock.Draw(spriteBatch, new Vector2 (position.X - 100, position.Y));
            cyclableItem.Draw(spriteBatch, new Vector2(position.X - 200, position.Y));

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
