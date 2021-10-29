using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerMoveDownCommand : ICommand
    {
        IPlayer player;

        public PlayerMoveDownCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            // Set the players down input as pressed
            player.SetMoveInput(Direction.Down, true);
        }
    }
}
