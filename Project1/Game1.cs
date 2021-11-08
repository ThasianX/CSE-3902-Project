using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Controllers;
using Project1.Interfaces;
using Project1.GameStates;
using Project1.Levels;

namespace Project1
{
    public class Game1 : Game
    {
        public IGameState gameState;
        public GameTime inGameTime;

        private static GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private readonly int nativeX = 256, nativeY = 176;

        private int renderScale = 1;
        RenderTarget2D scene;
        RenderTarget2D HUD;

        private Vector2 HUDPosition = Vector2.Zero;
        private Vector2 scenePosition = new Vector2(0, 0);

        private ArrayList controllerList;

        private static Viewport ViewPort => graphics.GraphicsDevice.Viewport;
        public static int SCREEN_WIDTH => ViewPort.Width;
        public static int SCREEN_HEIGHT => ViewPort.Height;

        // Visualize rectangle for testing
        public static Texture2D whiteRectangle;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Window.AllowUserResizing = true;
            // Register window size change event
            Window.ClientSizeChanged += OnWindowResize;
        }

        // We could use initialize to Reset our game
        protected override void Initialize()
        {
            HUD = new RenderTarget2D(graphics.GraphicsDevice, 256, 64);
            scene = new RenderTarget2D(graphics.GraphicsDevice, 256, 176);
            OnWindowResize(this, null);

            controllerList = new ArrayList
            {
                new KeyboardController(this),
                new MouseController(this)
            };

            inGameTime = new GameTime();

            gameState = new PlayingGameState(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteFactory.Instance.LoadAllTextures(Content);
            SpriteFactory.Instance.LoadAllFonts(Content);
            SpriteFactory.Instance.LoadSpriteData("Data/sprite_data.xml");
            SpriteFactory.Instance.loadSpriteDictionary("Data/sprite_dictionary.xml");

            LevelManager.Instance.LoadLevel();
            CollisionHandler.Instance.LoadResponses("Data/collision_response.xml");

            // Visualize rectangle for testing
            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });

            foreach (IController controller in controllerList)
            {
                controller.RegisterPlayer(GameObjectManager.Instance.GetPlayer());
                controller.RegisterCommands();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            gameState.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Draw to the scene and HUD render targets
            RenderScene();
            RenderHUD();

            // Draw the render targets to their places in the game window
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Scale and draw the scene
            spriteBatch.Draw(scene, scenePosition, null, Color.White, 0f, Vector2.Zero, renderScale, SpriteEffects.None, 0f);

            //Scale and draw the HUD
            spriteBatch.Draw(HUD, HUDPosition, null, Color.White, 0f, Vector2.Zero, renderScale, SpriteEffects.None, 0f);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Reset()
        {
            // TODO
        }

        private void RenderScene()
        {
            // Draw the game area to the scene render target
            GraphicsDevice.SetRenderTarget(scene);
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            gameState.Draw(spriteBatch);
            spriteBatch.End();

            // Draw the HUD area to the HUD render target
            GraphicsDevice.SetRenderTarget(HUD);
            GraphicsDevice.Clear(Color.Black);
        }

       private void RenderHUD()
        {
            // Draw the HUD area to the HUD render target
            GraphicsDevice.SetRenderTarget(HUD);
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            //TODO: HUDManager.Draw
            spriteBatch.End();
        }

        private void OnWindowResize(Object sender, EventArgs e)
        {
            // calculate biggest render scale that won't distort pixels
            int gameWidth = Math.Max(HUD.Width, scene.Width);
            int gameHeight = HUD.Height + scene.Height;
            renderScale = Math.Min(Window.ClientBounds.Width / gameWidth, Window.ClientBounds.Height / gameHeight);
            if (renderScale < 1)
                renderScale = 1;

            // center the entire game
            Vector2 gamePosition;
            gamePosition.X = (Window.ClientBounds.Width / 2) - ((gameWidth * renderScale) / 2);
            gamePosition.Y = (Window.ClientBounds.Height / 2) - ((gameHeight * renderScale) / 2);

            // Align HUD and scene
            HUDPosition = gamePosition;
            scenePosition.X = gamePosition.X;
            scenePosition.Y = gamePosition.Y + (HUD.Height * renderScale);
        }
        public void UpdateInGameTime()
        {
            base.Update(inGameTime);
        }

    }
}
