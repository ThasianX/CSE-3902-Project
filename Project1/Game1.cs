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

        private LevelManager _levelManager;
        public LevelManager levelManager 
        {
            get { return _levelManager; }
        }

        private ArrayList controllerList;
        private CollisionManager collisionManager;

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
            _levelManager = new LevelManager(1);
        }

        void Setup()
        {
            _levelManager.LoadLevel();
            SetupControllers();
        }

        public void SetupControllers() {
            controllerList = new ArrayList
            {
                new KeyboardController(this),
                new MouseController(this)
            };
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteFactory.Instance.LoadAllTextures(Content);
            SpriteFactory.Instance.LoadAllFonts(Content);
            SpriteFactory.Instance.LoadSpriteData("Data/sprite_data.xml");
            SpriteFactory.Instance.loadSpriteDictionary("Data/sprite_dictionary.xml");

            Setup();
            collisionManager = new CollisionManager(levelManager, new CollisionHandler("Data/collision_response.xml"));
            
            // Visualize rectangle for testing
            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            _levelManager.GetCurrentRoom().Update(gameTime);

            collisionManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            _levelManager.GetCurrentRoom().Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Reset() 
        {
            Setup();
        }
    }
}
