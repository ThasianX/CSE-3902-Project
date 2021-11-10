using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerCollectRupeeCommand : ICommand
    {
        private IPlayer player;
        private IRupee rupee;
        public PlayerCollectRupeeCommand(Collision col)
        {
            this.player = col.target as IPlayer;
            this.rupee = col.source as IRupee;
        }
        public void Execute()
        {
            player.CollectRupee(rupee);
            SoundManager.Instance.PlaySound("GetRupee");
        }
    }
}