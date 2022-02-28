using Project1.Interfaces;

namespace Project1.Commands
{
    class QuitCommand: ICommand
    {
        private readonly Game1 myGame;

        public QuitCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Exit();
        }
    }
}
//Team JellyLake Autumn 2021
