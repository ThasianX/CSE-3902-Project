using Project1.Enemy;
using Project1.Interfaces;

namespace Project1.Commands
{
    class DeleteProjectileByOwnerCommand : ICommand
    {
        private IGameObject owner;
        private IProjectile projectile;
        private bool remove = false;

        public DeleteProjectileByOwnerCommand(IProjectile projectile)
        {
            this.projectile = projectile;
            // if enemy hit projectile but enemy owns the projectile, don't delete
            if (projectile.Owner is IEnemy)
            {
                remove = false;
            }
            else
            {
                remove = true;
            }
        }

        public DeleteProjectileByOwnerCommand(IGameObject owner, IProjectile projectile)
        {
            this.owner = owner;
            this.projectile = projectile;
            if (projectile.Owner == owner)
            {
                remove = true;
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