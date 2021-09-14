using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Controllers;
using Project1.Interfaces;
using Project1.Sprites;

namespace Project1
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private ISprite sprite;

        private Vector2 position;

        private ArrayList controllerList;

        private SpriteFont font;
        private int score = 0;

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
            sprite = new StillSprite(spriteSheet);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            sprite.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            sprite.Draw(spriteBatch, position);
            spriteBatch.DrawString(font, "Credits", new Vector2(100, 100), Color.Black);
            spriteBatch.DrawString(font, "Program Made By Kevin Li", new Vector2(100, 120), Color.Black);
            spriteBatch.DrawString(font, "Sprites from: http://www.mariouniverse.com/wp-content/img/sprites/nes/smb/enemies.png", new Vector2(100, 140), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        internal void SetSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }

        internal void ShiftPosition(int x, int y)
        {
            int newX = (int)position.X + x;
            if (newX < -SpriteDimensions.WIDTH)
            {
                newX = SCREEN_WIDTH;
            }
            else if (newX > SCREEN_WIDTH)
            {
                newX = -SpriteDimensions.WIDTH;
            }

            int newY = (int)position.Y + y;
            if (newY < -SpriteDimensions.HEIGHT)
            {
                newY = SCREEN_HEIGHT;
            }
            else if (newY > SCREEN_HEIGHT)
            {
                newY = -SpriteDimensions.HEIGHT;
            }

            position = new Vector2(newX, newY);
        }
    }
}
