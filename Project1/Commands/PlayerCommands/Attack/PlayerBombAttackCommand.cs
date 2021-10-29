using Project1.Interfaces;

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
