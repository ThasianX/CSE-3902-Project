using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerStopMoveLeftCommand : ICommand
    {
        IPlayer player;

        public PlayerStopMoveLeftCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            // Set the players left input as released
            player.SetMoveInput(Direction.Left, false);
        }
    }
}
