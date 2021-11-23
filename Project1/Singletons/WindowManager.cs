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
        
        private float timePerSource = 1, timeCounter = 1;
        private Vector3 currentPosition = new Vector3(0, 0, 0);
        private Vector3 destinationPosition = new Vector3(0, 0, 0);

        public void StartCurrentRoom(SpriteBatch spriteBatch)
        {
            Vector3 newTranslation = Vector3.Multiply(destinationPosition - currentPosition, timeCounter);
            spriteBatch.Begin(
              samplerState: SamplerState.PointClamp,
              transformMatrix: Matrix.CreateTranslation(newTranslation)
            );
        }

        public void MoveCamera(Vector3 position)
        {
            Game1.instance.gameState = new PausedNoViewGameState();
            timeCounter = 0;
            destinationPosition = position;
        }

        public void Update(GameTime gameTime)
        {
            if(timeCounter == timePerSource) {
                return;
            } else if (timeCounter > timePerSource)
            {
              Game1.instance.gameState = new PlayingGameState(Game1.instance);
              timeCounter = timePerSource;
              currentPosition = destinationPosition;
              LevelManager.Instance.DeactivateCurrentRoom();
              return;
            }

            // increment the timer by the realtime since last frame
            timeCounter += (float) gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}