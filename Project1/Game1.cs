using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Controllers;
using Project1.Interfaces;
using Project1.Levels;

namespace Project1
{
    public class Game1 : Game
    {
        private static GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private readonly int nativeX = 256, nativeY = 240;

        private int renderScale = 6;
        RenderTarget2D scene;
        RenderTarget2D HUD;

        private Vector2 UIPosition = Vector2.Zero;
        private Vector2 scenePosition = new Vector2(0, 80);

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
            scene = new RenderTarget2D(graphics.GraphicsDevice, nativeX, nativeY);
            
            controllerList = new ArrayList
            {
                new KeyboardController(this),
                new MouseController(this)
            };

            base.Initialize();
        }

        void Setup()
        {
            LevelManager.Instance.LoadLevel();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteFactory.Instance.LoadAllTextures(Content);
            SpriteFactory.Instance.LoadAllFonts(Content);
            SpriteFactory.Instance.LoadSpriteData("Data/sprite_data.xml");
            SpriteFactory.Instance.loadSpriteDictionary("Data/sprite_dictionary.xml");

            Setup();
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

            GameObjectManager.Instance.UpdateObjects(gameTime);

            CollisionManager.Instance.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Draw the game area to the scene render target
            GraphicsDevice.SetRenderTarget(scene);
            GraphicsDevice.Clear(Color.Transparent);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            GameObjectManager.Instance.DrawObjects(spriteBatch);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Transparent);

            // Draw the HUD area to the HUD render target
            //TODO

            // Draw the different render targets to their places in the game window

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Scale and draw the scene
            spriteBatch.Draw(scene, scenePosition, null, Color.White, 0f, Vector2.Zero, renderScale, SpriteEffects.None, 0f);

            //Scale and draw the UI
            //TODO

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void RenderScene()
        {

        }

        public void Reset() 
        {
            // TODO: This have problem when press R because KeyBoardController already initialized
            Setup();
        }

        private void OnWindowResize(Object sender, EventArgs e)
        {
            int clientSize = Math.Min(Window.ClientBounds.Width, Window.ClientBounds.Height);
            renderScale = clientSize / nativeX;
            
            scenePosition.X = (Window.ClientBounds.Width / 2) - (scene.Width * renderScale / 2);
            scenePosition.Y = (Window.ClientBounds.Height / 2) - (scene.Height * renderScale / 2);
        }
    }
}
