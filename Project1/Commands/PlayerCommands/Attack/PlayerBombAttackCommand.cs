using Project1.Interfaces;
using Project1.PlayerStates;

namespace Project1.Commands
{
    class PlayerBombAttackCommand : ICommand
    {
        IPlayer player;

        public PlayerBombAttackCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.BombAttack();
        }
    }
}
