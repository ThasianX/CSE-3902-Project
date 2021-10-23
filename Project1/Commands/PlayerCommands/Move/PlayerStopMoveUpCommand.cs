using Project1.Interfaces;
using Project1.PlayerStates;

namespace Project1.Commands
{
    class PlayerStopMoveUpCommand : ICommand
    {
        IPlayer player;

        public PlayerStopMoveUpCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            // Set the players up input as released
            player.SetMoveInput(Direction.Up, false);
        }
    }
}
