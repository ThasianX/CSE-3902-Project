using Project1.Interfaces;

namespace Project1.Commands
{
    class DeleteProjectileCommand : ICommand
    {
        IProjectile projectile;
        private bool remove = true;

        public DeleteProjectileCommand(IProjectile projectile)
        {
            this.projectile = projectile;
            if (projectile.ProjectileOwner == Owner.Enemy)
            {
                remove = false;
            }
        }

        public void Execute()
        {
            if (remove)
            {
                GameObjectManager.Instance.RemoveOnNextFrame(projectile);
            }
        }
    }
}