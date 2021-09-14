using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using LinkGame.Interfaces;
using LinkGame.Link;



namespace LinkGame
{
    public class LinkGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteBatch spriteBatch;
        public Texture2D linkSpriteTexture;
        public Texture2D eagleLvl;
        private LinkSpriteFactory linkSpriteManager;
        private SpriteFont font;
        private TextSprite textSprite;
        private ArrayList controllers;
        private Vector2 centerScreen;
        public int spriteMode;

        public LinkGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void Quit()
        {
            this.Exit();
        }

        protected override void Initialize()
        {
            //Create list of Controllers (example from class)
            controllers = new ArrayList();
            controllers.Add(new KeyboardController(this));
            controllers.Add(new MouseController(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Texture sheets
            linkSpriteTexture = Content.Load<Texture2D>("images/linkSprite");
            eagleLvl = Content.Load<Texture2D>("images/eagle");
            font = Content.Load<SpriteFont>("SpriteFont");

            linkSpriteManager = new LinkSpriteFactory(linkSpriteTexture);

            linkSpriteManager.LinkSpriteCreation();

            textSprite = new TextSprite(font);

            spriteMode = 0;

            centerScreen = new Vector2(400, 240);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Updates controllers
            foreach (IController controller in controllers)
            {
                spriteMode = controller.Update(spriteMode);
            }

            linkSpriteManager.Update(gameTime, spriteMode);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            linkSpriteManager.Draw(spriteBatch, centerScreen, spriteMode);

            textSprite.Draw(spriteBatch, new Vector2(200, 300));

            base.Draw(gameTime);
        }
    }
}
