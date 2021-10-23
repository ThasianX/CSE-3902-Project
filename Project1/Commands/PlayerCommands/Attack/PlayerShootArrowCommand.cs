using Project1.Interfaces;
using Project1.PlayerStates;

namespace Project1.Commands
{
    class PlayerShootArrowCommand : ICommand
    {
        IPlayer player;

        public PlayerShootArrowCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.ShootArrow();
        }
    }
}
