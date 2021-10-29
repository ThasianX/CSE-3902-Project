using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerStopMoveRightCommand : ICommand
    {
        IPlayer player;

        public PlayerStopMoveRightCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            // Set the players right input as released
            player.SetMoveInput(Direction.Right, false);
        }
    }
}
