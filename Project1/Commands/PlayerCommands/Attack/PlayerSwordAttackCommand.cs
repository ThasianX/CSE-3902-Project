using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerSwordAttackCommand : ICommand
    {
        IPlayer player;

        public PlayerSwordAttackCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.SwordAttack();
        }
    }
}
