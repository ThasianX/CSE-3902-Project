using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerFaceLeftCommand : ICommand
    {
        IPlayer player;

        public PlayerFaceLeftCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.FaceDirection(Direction.Left);
        }
    }
}
