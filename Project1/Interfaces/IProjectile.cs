namespace Project1.Interfaces
{
    public interface IProjectile : IGameObject
    {
        IGameObject Owner { get; set; }
    }
}
