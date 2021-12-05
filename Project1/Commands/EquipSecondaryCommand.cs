using System;
using System.Collections.Generic;
using System.Text;
using Project1.Interfaces;

namespace Project1.Commands
{
    class EquipSecondaryCommand : ICommand
    {
        Game1 game;

        public EquipSecondaryCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.gameState.GetType() == new GameStates.PausedGameState(game).GetType())
                InventoryManager.Instance.EquipSelectedSecondary();
        }
    }
}
