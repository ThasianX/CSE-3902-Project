using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class PlayerTakeDamageCommand : ICommand
    {
        Player player;
        int amount = 2; // default amount

        public PlayerTakeDamageCommand(Player player, int amount)
        {
            this.player = player;
            this.amount = amount;
        }

        public PlayerTakeDamageCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.TakeDamage(amount);
        }
    }
}
