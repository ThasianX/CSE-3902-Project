using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerCollectItemCommand : ICommand
    {
        private IPlayer player;
        private IInventoryItem collectible;
        public PlayerCollectItemCommand(Collision col)
        {
            this.player = col.target as IPlayer;
            this.collectible = col.source as IInventoryItem;
        }
        public void Execute()
        {
            // add collectible game object to player collection
            player.CollectItem(collectible);
            SoundManager.Instance.PlaySound("GetItem");
        }
    }
}