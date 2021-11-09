

namespace Project1.Interfaces
{
    interface IController
    {
        void Update();
        void RegisterPlayer(IPlayer player);
        void RegisterCommands();

        public void ClearData();
    }
}
