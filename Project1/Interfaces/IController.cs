﻿using Project1.PlayerStates;

namespace Project1.Interfaces
{
    interface IController
    {
        void Update();
        void RegisterPlayer(IPlayer player);
        void RegisterCommands();
    }
}
