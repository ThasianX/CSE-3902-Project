using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

// Jake Suraba.2
namespace Project1
{
    public class Game1 : Game
    {
        
        private StaticSprite staticSprite;
        private AnimatedStaticSprite animatedStaticSprite;
        private DynamicSprite dynamicSprite;
        private AnimatedDynamicSprite animatedDynamicSprite;

        private SpriteFont font;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        KeyboardController keyboardController;
        MouseController mouseController;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Load the unanimated sprite and create instances
            Texture2D texture = Content.Load<Texture2D>("mario_Tpose");

            staticSprite = new StaticSprite(texture);
            dynamicSprite = new DynamicSprite(texture, 5, Window.ClientBounds.Height);

            // Load the animated sprite and create instances
            texture = Content.Load<Texture2D>("mario_walk");

            animatedStaticSprite = new AnimatedStaticSprite(texture, 1, 3);
            animatedDynamicSprite = new AnimatedDynamicSprite(texture, 1, 3, 5, Window.ClientBounds.Width);
            
            font = Content.Load<SpriteFont>("File");

            // array of all sprites to make things easier !!!USE MANAGER INSTEAD!!!
            ISprite[] allSprites = { staticSprite, dynamicSprite, animatedStaticSprite, animatedDynamicSprite };

            //Define Commands (Too wordy... also should store in XML)
            QuitCommand quitCommand = new QuitCommand(this);
            StaticSpriteCommand staticSpriteCommand = new StaticSpriteCommand(staticSprite, allSprites);
            AnimatedStaticSpriteCommand animatedStaticSpriteCommand = new AnimatedStaticSpriteCommand(animatedStaticSprite, allSprites);
            DynamicSpriteCommand dynamicSpriteCommand = new DynamicSpriteCommand(dynamicSprite, allSprites);
            AnimatedDynamicSpriteCommand animatedDynamicSpriteCommand = new AnimatedDynamicSpriteCommand(animatedDynamicSprite, allSprites);

            // initial state
            staticSpriteCommand.Execute();

            // Create the keyboard controller
            keyboardController = new KeyboardController();

            // Define which keys are bound to which commands. (Should probably read this from an xml file...)
            keyboardController.RegisterCommand(Keys.D0, quitCommand);
            keyboardController.RegisterCommand(Keys.D1, staticSpriteCommand);
            keyboardController.RegisterCommand(Keys.D2, animatedStaticSpriteCommand);
            keyboardController.RegisterCommand(Keys.D3, dynamicSpriteCommand);
            keyboardController.RegisterCommand(Keys.D4, animatedDynamicSpriteCommand);

            //create the mouse controller
            mouseController = new MouseController(this);

            // to make splitting the screen into quads easier
            int quadWidth = Window.ClientBounds.Width / 2;
            int quadHeight = Window.ClientBounds.Height / 2;
            Rectangle quad = new Rectangle(0, 0, quadWidth, quadHeight);

            // Define the screen space that corresponds to each command
            mouseController.RegisterButton(quad, staticSpriteCommand);
            quad.Offset(quadWidth, 0);
            mouseController.RegisterButton(quad, animatedStaticSpriteCommand);
            quad.Offset(0, quadHeight);
            mouseController.RegisterButton(quad, animatedDynamicSpriteCommand);
            quad.Offset(-quadWidth, 0);
            mouseController.RegisterButton(quad, dynamicSpriteCommand);


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
           
            // Update Controllers
            keyboardController.Update();
            mouseController.Update();

            // Update sprites
            animatedStaticSprite.Update();
            dynamicSprite.Update();
            animatedDynamicSprite.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            // center of the game window
            Vector2 center = new Vector2(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2);

            spriteBatch.Begin();

            //Draw Credits
            spriteBatch.DrawString(font, "Credits\nProgram made by: Jake Suraba\nSprites From: http://www.mariouniverse.com/wp-content/img/sprites/snes/smw/mario-3.png", new Vector2(100, 100), Color.Black);

            // Draw sprites
            staticSprite.Draw(spriteBatch, center);
            animatedStaticSprite.Draw(spriteBatch, center);
            dynamicSprite.Draw(spriteBatch, new Vector2(center.X, 0));
            animatedDynamicSprite.Draw(spriteBatch, new Vector2(0, center.Y));

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
