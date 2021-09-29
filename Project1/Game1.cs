using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Commands;
using Project1.Controllers;
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

        private Vector2 position;

        private ArrayList controllerList;

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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            link.Draw();

            cyclableBlock.Draw(spriteBatch, new Vector2 (position.X - 100, position.Y));
            cyclableItem.Draw(spriteBatch, new Vector2(position.X - 200, position.Y));

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
