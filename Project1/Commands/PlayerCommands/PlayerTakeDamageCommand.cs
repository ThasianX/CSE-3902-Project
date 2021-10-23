using Project1.Interfaces;
using Project1.PlayerStates;

namespace Project1.Commands
{
    class PlayerTakeDamageCommand : ICommand
    {
        IPlayer player;
        int amount = 2; // default amount

        public PlayerTakeDamageCommand(IPlayer player, int amount)
        {
            this.player = player;
            this.amount = amount;
        }

        public void Execute()
        {
            player.TakeDamage(amount);
        }
    }
}
