using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Levels;
using Project1.GameStates;


namespace Project1
{
    class WindowManager
    {
        private static WindowManager instance = new WindowManager();

        public static WindowManager Instance
        {
            get
            {
                return instance;
            }
        }
        
        private float startX = 0;
        private double timePerSource = 1, timeCounter = 1;
        private int currentFrame = 0;
        private Vector3 currentTranslation = new Vector3(0, 0, 0);
        private Vector3 startTranslation = new Vector3(0, 0, 0);
        private Direction currentDirection = Direction.Left;

        public void StartCurrentRoom(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(
              samplerState: SamplerState.PointClamp,
              transformMatrix: Matrix.CreateTranslation(currentTranslation)
            );
        }

        public void StartNextRoom(SpriteBatch spriteBatch)
        {
            Vector3 newTranslation = currentTranslation;
            switch(currentDirection) {
                case Direction.Up:
                    newTranslation.Y -= Game1.ROOM_HEIGHT;
                    break;
                case Direction.Down:
                    newTranslation.Y += Game1.ROOM_HEIGHT;
                    break;
                case Direction.Left:
                    newTranslation.X -= Game1.ROOM_WIDTH;
                    break;
                case Direction.Right:
                    newTranslation.X += Game1.ROOM_WIDTH;
                    break;
                default:
                    throw new System.Exception("Invalid direction");
            }
            spriteBatch.Begin(
              samplerState: SamplerState.PointClamp,
              transformMatrix: Matrix.CreateTranslation(newTranslation)
            );
        }

        public void MoveCamera(Direction direction)
        {
            Game1.instance.gameState = new PausedNoViewGameState();
            timeCounter = 0;
            startTranslation = currentTranslation;
            currentDirection = direction;
        }

        public void Update(GameTime gameTime)
        {
            if (timeCounter >= timePerSource)
            {
                if(!Game1.instance.isTransitioning)
                {
                    return;
                }
              Game1.instance.gameState = new PlayingGameState(Game1.instance);
              timeCounter = timePerSource;
              Game1.instance.isTransitioning = false;
              LevelManager.Instance.DeactiveCurrentRoom(Game1.instance.nextRoomId);
              currentTranslation = new Vector3(0, 0, 0);
              return;
            }

            // increment the timer by the realtime since last frame
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
            switch(currentDirection) {
                case Direction.Up:
                    currentTranslation.Y = startTranslation.Y + (float)(Game1.ROOM_HEIGHT * timeCounter / timePerSource);
                    break;
                case Direction.Down:
                    currentTranslation.Y = startTranslation.Y - (float)(Game1.ROOM_HEIGHT * timeCounter / timePerSource);
                    break;
                case Direction.Left:
                    currentTranslation.X = startTranslation.X + (float)(Game1.ROOM_WIDTH * timeCounter / timePerSource);
                    break;
                case Direction.Right:
                    currentTranslation.X = startTranslation.X - (float)(Game1.ROOM_WIDTH * timeCounter / timePerSource);
                    break;
                default:
                    throw new System.Exception("Invalid direction");
            }
        }
    }
}
//Team JellyLake Autumn 2021
