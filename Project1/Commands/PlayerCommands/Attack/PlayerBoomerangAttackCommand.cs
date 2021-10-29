using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerBoomerangAttackCommand : ICommand
    {
        IPlayer player;

        public PlayerBoomerangAttackCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.BoomerangAttack();
        }
    }
}
