﻿using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Commands
{
    class DeleteGameObjectCommand : ICommand
    {
        IGameObject obj;

        public DeleteGameObjectCommand(IGameObject obj)
        {
            this.obj = obj;
        }

        public void Execute()
        {
            GameObjectManager.Instance.RemoveOnNextFrame(obj);
        }
    }
}
