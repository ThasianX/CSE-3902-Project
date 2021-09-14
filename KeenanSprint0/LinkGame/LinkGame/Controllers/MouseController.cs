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
    class MouseController : IController
    {
        private MouseState oldState;
        private Game game;


        public MouseController(Game game1)
        {
            oldState = Mouse.GetState();
            game = game1;
        }


        public int Update(int prevMode)
        {
            MouseState newState = Mouse.GetState();
            int mode = 0;
            // Was Key 0 Pressed.. quit
            if ((oldState.RightButton != ButtonState.Pressed) && (newState.RightButton == ButtonState.Pressed))
            {
                game.Exit();
            }
            
            // If Left Mouse Button was Pressed..
            if ((oldState.LeftButton != ButtonState.Pressed) && (newState.LeftButton == ButtonState.Pressed)){
                // ..in the top left quarter of the window, should display a sprite with only one frame of animation and a fixed position
                if (newState.X <= 400 && newState.Y <= 240)
                {
                    mode = 1;
                }

                // ..in the top right quarter of the window, should display an animated sprite, but with a fixed position 
                if (newState.X > 400 && newState.Y <= 240)
                {
                    mode = 2;
                }
                // ..in the bottom left quarter of the window, should display a sprite with only one frame of animation, but moves the sprite up and down on screen
                if (newState.X <= 400 && newState.Y > 240)
                {
                    mode = 3;
                }
                // ..in the bottom right quarter of the window, should display an animated sprite, moving to the left and right on screen
                if (newState.X > 400 && newState.Y > 240)
                {
                    mode = 4;
                }
            }

            // Update saved state
            oldState = newState;
            if (mode == 0)
            {
                return prevMode;
            }
            return mode;
        }


    }
}
