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
            _levelManager = new LevelManager(1);
           
            controllerList = new ArrayList
            {
                new KeyboardController(this),
                new MouseController(this)
            };

            base.Initialize();
        }

        void Setup()
        {
            _levelManager.LoadLevel();
            foreach (IController controller in controllerList) {
                controller.RegisterPlayer(GameObjectManager.Instance.GetPlayer());
                controller.RegisterCommands();
            }
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            GameObjectManager.Instance.DrawObjects(spriteBatch);

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
