using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerMoveUpCommand : ICommand
    {
        IPlayer player;

        public PlayerMoveUpCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            // Set the players up input as pressed
            player.SetMoveInput(Direction.Up, true);
        }
    }
}
