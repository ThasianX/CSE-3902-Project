using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerKnockBackCommand : ICommand
    {
        private IPlayer player;
        private Direction damagedSide;

        public PlayerKnockBackCommand(IPlayer player, Collision col)
        {
            this.player = player;
            damagedSide = col.side;
        }

        public void Execute()
        {
           player.KnockBack(damagedSide);
        }
    }
}