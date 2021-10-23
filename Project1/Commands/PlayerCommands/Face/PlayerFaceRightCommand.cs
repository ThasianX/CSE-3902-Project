using Project1.Interfaces;
using Project1.PlayerStates;

namespace Project1.Commands
{
    class PlayerFaceRightCommand : ICommand
    {
        IPlayer player;

        public PlayerFaceRightCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.FaceDirection(Direction.Right);
        }
    }
}
