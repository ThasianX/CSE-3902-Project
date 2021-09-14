using System;

namespace LinkGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new LinkGame())
                game.Run();
        }
    }
}
