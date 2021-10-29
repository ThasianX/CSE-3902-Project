using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerMoveLeftCommand : ICommand
    {
        IPlayer player;

        public PlayerMoveLeftCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            // Set the players left input as pressed
            player.SetMoveInput(Direction.Left, true);
        }
    }
}
