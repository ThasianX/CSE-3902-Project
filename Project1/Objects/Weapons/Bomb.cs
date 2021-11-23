using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Bomb : IGameObject
    {
        public Vector2 Position { get; set; }
        ISprite sprite;
        public bool IsMover => false;
        //Unsure what collision type the placed bomb should have.
        public string CollisionType => "Block";
        private double activeTime = 1;
        private double counter = 0;
        public Bomb(Vector2 position)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateSprite("bomb");
            SoundManager.Instance.PlaySound("BombDrop");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (counter >= activeTime)
            {
                Explode();
            }
            counter += gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Explode()
        {
            GameObjectManager.Instance.RemoveOnNextFrame(this);
            GameObjectManager.Instance.AddOnNextFrame(new Explosion(Position));
            GameObjectManager.Instance.AddOnNextFrame(new Explosion(Position + new Vector2(16, 0)));
            GameObjectManager.Instance.AddOnNextFrame(new Explosion(Position + new Vector2(-16, 0)));
            GameObjectManager.Instance.AddOnNextFrame(new Explosion(Position + new Vector2(8, 16)));
            GameObjectManager.Instance.AddOnNextFrame(new Explosion(Position + new Vector2(-8, 16)));
            GameObjectManager.Instance.AddOnNextFrame(new Explosion(Position + new Vector2(8, -16)));
            GameObjectManager.Instance.AddOnNextFrame(new Explosion(Position + new Vector2(-8, -16)));
        }
    }
}
