using Project1.Interfaces;

namespace Project1.Commands
{
    class PickUpCommand : ICommand
    {
        private IPlayer player;
        private IInventoryItem collectible;
        public PickUpCommand(Collision col)
        {
            this.player = col.target as IPlayer;
            this.collectible = col.source as IInventoryItem;
        }
        public void Execute()
        {
            player.CollectItem(collectible);
            Game1.instance.gameState.PickUp(player, collectible);
        }
    }
}
//Team JellyLake Autumn 2021
