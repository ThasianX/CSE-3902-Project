using Microsoft.Xna.Framework;

namespace Project1.Interfaces
{
    public interface IPortal: IGameObject
    {
        public Vector2 NewRoomPosition { get; set; }
        int NextRoom { get; }
        public Direction Direction { get; }
    }
}