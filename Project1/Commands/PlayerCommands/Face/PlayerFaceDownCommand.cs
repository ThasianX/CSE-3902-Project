using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerFaceDownCommand : ICommand
    {
        IPlayer player;

        public PlayerFaceDownCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.FaceDirection(Direction.Down);
        }
    }
}
