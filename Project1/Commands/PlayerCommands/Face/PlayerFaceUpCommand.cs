using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerFaceUpCommand : ICommand
    {
        Game1 game;

        public PlayerFaceUpCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            foreach (Player player in GameObjectManager.Instance.GetObjectsOfType<Player>())
            {
                player.FaceDirection(Direction.Up);
            }
        }
    }
}
