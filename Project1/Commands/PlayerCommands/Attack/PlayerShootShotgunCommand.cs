using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerShootShotgunCommand : ICommand
    {
        IPlayer player;

        public PlayerShootShotgunCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.ShootShotGun();
        }
    }
}