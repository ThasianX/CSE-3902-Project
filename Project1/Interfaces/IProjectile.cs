namespace Project1.Interfaces
{
    public interface IProjectile : IGameObject
    {
        Owner WeaponOwner { get; set; }
    }
}
