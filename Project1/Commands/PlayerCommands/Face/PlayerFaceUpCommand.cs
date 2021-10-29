using Project1.Interfaces;

namespace Project1.Commands
{
    class PlayerFaceUpCommand : ICommand
    {
        IPlayer player;

        public PlayerFaceUpCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.FaceDirection(Direction.Up);
        }
    }
}
