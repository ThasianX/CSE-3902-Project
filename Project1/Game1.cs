using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Controllers;
using Project1.Enemy;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Vector2 position;
        private Vector2 enemyPosition;
        private Vector2 blockPosition;

        private ArrayList controllerList;
        private CollisionManager collisionManager;

        private Viewport ViewPort => graphics.GraphicsDevice.Viewport;
        public int SCREEN_WIDTH => ViewPort.Width;
        public int SCREEN_HEIGHT => ViewPort.Height;

        public Texture2D spriteSheet;

        // Visualize rectangle for testing
        public static Texture2D whiteRectangle;
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
            blockPosition = new Vector2(SCREEN_WIDTH / 4 , SCREEN_HEIGHT / 4);

            controllerList = new ArrayList
            {
                new KeyboardController(this),
                new MouseController(this)
            };

            base.Initialize();
        }

        void Setup()
        {
            GameObjectManager.Instance.Add(new Player(position));
            GameObjectManager.Instance.Add(new Stalfos(enemyPosition));
            GameObjectManager.Instance.Add(new LadderBlock(blockPosition));

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteFactory.Instance.LoadAllTextures(Content);
            SpriteFactory.Instance.LoadAllFonts(Content);
            SpriteFactory.Instance.LoadSpriteData("Data/sprite_data.xml");
            SpriteFactory.Instance.loadSpriteDictionary("Data/sprite_dictionary.xml");

            CollisionHandler.Instance.LoadResponseData("Data/collision_response.xml");

            Setup();
            collisionManager = new CollisionManager(GameObjectManager.Instance);
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
            collisionManager.Update();
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
            Setup();
        }
    }
}
