using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerUsePrimaryCommand : ICommand
    {
        IPlayer player;

        public PlayerUsePrimaryCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            InventoryManager.Instance.UsePrimary(player);
        }
    }
}
//Team JellyLake Autumn 2021
