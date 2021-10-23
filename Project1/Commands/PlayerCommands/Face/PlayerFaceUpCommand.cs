using Project1.Interfaces;
using Project1.PlayerStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerFaceUpCommand : ICommand
    {
        IPlayer player;

        public PlayerFaceUpCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.FaceDirection(Direction.Up);
        }
    }
}
