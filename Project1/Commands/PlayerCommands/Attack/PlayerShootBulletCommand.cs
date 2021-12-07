using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerShootBulletCommand : ICommand
    {
        IPlayer player;

        public PlayerShootBulletCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.ShootBullet();
        }
    }
}
