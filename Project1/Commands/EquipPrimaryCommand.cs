using System;
using System.Collections.Generic;
using System.Text;
using Project1.Interfaces;

namespace Project1.Commands
{
    class EquipPrimaryCommand : ICommand
    {
        Game1 game;

        public EquipPrimaryCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.gameState.GetType() == new GameStates.PausedGameState(game).GetType())
                InventoryManager.Instance.EquipSelectedPrimary();
        }
    }
}
