using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.Commands
{
    class DropArrowCommand : ICommand
    {
        private Vector2 position;

        private Vector2 offset = new Vector2(4, 0);

        public DropArrowCommand(IGameObject arrow)
        {
            position = arrow.Position + offset;
        }

        public void Execute()
        {
            GameObjectManager.Instance.AddOnNextFrame(new WoodArrowPickup(position));
        }
    }
}
