using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerStopMoveDownCommand : ICommand
    {
        IPlayer player;

        public PlayerStopMoveDownCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            // Set the players down input as released
            player.SetMoveInput(Direction.Down, false);
        }
    }
}
