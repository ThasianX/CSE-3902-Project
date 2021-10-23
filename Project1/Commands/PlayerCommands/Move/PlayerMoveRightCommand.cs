using Project1.Interfaces;
using Project1.PlayerStates;

namespace Project1.Commands
{
    class PlayerMoveRightCommand : ICommand
    {
        IPlayer player;

        public PlayerMoveRightCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            // Set the players right input as pressed
            player.SetMoveInput(Direction.Right, true);
        }
    }
}
