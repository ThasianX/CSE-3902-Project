using Microsoft.Xna.Framework;
using Project1.Interfaces;
using Project1.PlayerStates;

namespace Project1.Commands
{
    class OldKnockBackCommand : ICommand
    {
        private IGameObject target;
        private Direction damagedSide;
        private Vector2 KnockBackAmount;

        public OldKnockBackCommand(Collision col)
        {
            this.target = col.target as IGameObject;
            damagedSide = col.side;
            switch (damagedSide)
            {
                case Direction.Up: KnockBackAmount = new Vector2(0, -10); break;
                case Direction.Down: KnockBackAmount = new Vector2(0, 10); break;
                case Direction.Left: KnockBackAmount = new Vector2(-10, 0); break;
                case Direction.Right: KnockBackAmount = new Vector2(10, 0); break;
            }
        }

        public void Execute()
        {
            target.Position += KnockBackAmount;
            if (target is IPlayer)
            {
                IPlayer player = target as IPlayer;
                player.State = new StillPlayerState(player);
            }
        }
    }
}