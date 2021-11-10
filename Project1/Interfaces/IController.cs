

namespace Project1.Interfaces
{
    interface IController
    {
        void Update();
        void UpdateOnRelease();
        void RegisterPlayer(IPlayer player);
        void RegisterCommands();
        public void ClearData();
    }
}
