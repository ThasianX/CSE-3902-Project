using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerTakeDamageCommand : ICommand
    {
        IPlayer player;
        int amount = 1; // default amount
        private bool takeDamage = true;

        public PlayerTakeDamageCommand(IPlayer player, int amount)
        {
            this.player = player;
            this.amount = amount;
        }

        public PlayerTakeDamageCommand(IPlayer player)
        {
            this.player = player;
        }

        public PlayerTakeDamageCommand(IPlayer player, IProjectile projectile)
        {
            this.player = player;
            if (projectile.Owner is IPlayer)
            {
                takeDamage = false;
            }
        }

        public void Execute()
        {
            if (takeDamage)
            {
                player.TakeDamage(amount);
            }
        }
    }
}
