using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerShowCollectionCommand : ICommand
    {
        private IPlayer player;
        public PlayerShowCollectionCommand(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.ShowCollection();
        }
    }
}