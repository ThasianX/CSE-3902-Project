namespace Project1.Interfaces
{
    public interface IExit: IGameObject
    {
        public int nextRoom { get; }
        Direction direction { get; }
    }
}