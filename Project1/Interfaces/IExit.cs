namespace Project1.Interfaces
{
    public interface IExit: IGameObject
    {
        int nextRoom { get; }
        Direction direction { get; }
    }
}