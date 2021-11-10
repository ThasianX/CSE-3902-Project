using Project1.Interfaces;

namespace Project1.Commands
{
    class ResetCommand: ICommand
    {
        private readonly Game1 myGame;

        public ResetCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Reset();
        }
    }
}
