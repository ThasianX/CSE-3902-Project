using Project1.Enemy;
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
            if (projectile.Owner is IEnemy)
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