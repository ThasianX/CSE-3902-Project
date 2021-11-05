namespace Project1.Interfaces
{
    public interface IProjectile : IGameObject
    {
        Owner ProjectileOwner { get; set; }
    }
}
