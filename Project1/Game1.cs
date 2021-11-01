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

        RenderTarget2D scene;
        RenderTarget2D UI;

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
        }

        // We could use initialize to Reset our game
        protected override void Initialize()
        {
            scene = new RenderTarget2D(graphics.GraphicsDevice, SCREEN_WIDTH, SCREEN_HEIGHT);

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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            GameObjectManager.Instance.DrawObjects(spriteBatch);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Transparent);

            // Draw the UI area to the UI render target
            //TODO

            // Draw the different render targets to their places in the game window

            spriteBatch.Begin();

            // Scale and draw the scene
            float scale = 2.5f;
            spriteBatch.Draw(scene, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            //Scale and draw the UI
            //TODO

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Reset() 
        {
            // TODO: This have problem when press R because KeyBoardController already initialized
            Setup();
        }
    }
}
