using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerFaceLeftCommand : ICommand
    {
        Game1 game;

        public PlayerFaceLeftCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            foreach (Player player in GameObjectManager.Instance.GetObjectsOfType<Player>())
            {
                player.FaceDirection(Direction.Left);
            }
        }
    }
}
