using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerCollectInstantUseItemCommand : ICommand
    {
        private IPlayer player;
        private IInstantUseItem collectible;
        public PlayerCollectInstantUseItemCommand(Collision col)
        {
            this.player = col.target as IPlayer;
            this.collectible = col.source as IInstantUseItem;
        }
        public void Execute()
        {
            player.InstantUseItem(collectible);
        }
    }
}
//Team JellyLake Autumn 2021
