using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerUseSecondaryCommand : ICommand
    {
        IPlayer player;

        public PlayerUseSecondaryCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            InventoryManager.Instance.UseSecondary(player);
        }
    }
}
