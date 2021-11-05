using Project1.Interfaces;

namespace Project1.Commands
{
    class DeleteGameObjectCommand : ICommand
    {
        IGameObject obj;
        private bool remove = true;

        public DeleteGameObjectCommand(IGameObject obj)
        {
            this.obj = obj;
        }

        public DeleteGameObjectCommand(IProjectile projectile, Collision col)
        {
            obj = projectile;
            if (projectile.WeaponOwner == Owner.Enemy)
            {
                remove = false;
            }
        }

        public void Execute()
        {
            if (remove)
            {
                GameObjectManager.Instance.RemoveOnNextFrame(obj);
            }
        }
    }
}
