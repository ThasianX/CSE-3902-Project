using System;
using System.Collections.Generic;
using System.Text;
using LinkGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace LinkGame
{
    class KeyboardController : IController
    {
        private KeyboardState oldState;
        private Game game;
        
        public KeyboardController(Game game1)
        {
            oldState = Keyboard.GetState();
            game = game1;
        }


        public int Update(int prevMode)
        {
            KeyboardState newState = Keyboard.GetState();
            int mode = 0;
            // Was Key 0 Pressed.. quit
            if (!oldState.IsKeyDown(Keys.D0) && newState.IsKeyDown(Keys.D0))
            {
                game.Exit();
            }
            // Was Key 1 Pressed.. display a sprite with only one frame of animation and a fixed position
            if (!oldState.IsKeyDown(Keys.D1) && newState.IsKeyDown(Keys.D1))
            {
                mode = 1;
            }
            // Was Key 2 Pressed.. display an animated sprite, but with a fixed position
            if (!oldState.IsKeyDown(Keys.D2) && newState.IsKeyDown(Keys.D2))
            {
                mode = 2;
            }
            // Was Key 3 Pressed.. display a sprite with only one frame of animation, but moves the sprite up and down on screen
            if (!oldState.IsKeyDown(Keys.D3) && newState.IsKeyDown(Keys.D3))
            {
                mode = 3;
            }
            // Was Key 4 Pressed.. display an animated sprite, moving to the left and right on screen
            if (!oldState.IsKeyDown(Keys.D4) && newState.IsKeyDown(Keys.D4))
            {
                mode = 4;
            }
            if (mode == 0)
            {
                return prevMode;
            }
            // Update saved state
            oldState = newState;
            return mode;
        }


    }
}
