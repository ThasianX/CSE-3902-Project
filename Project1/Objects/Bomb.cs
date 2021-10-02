using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Bomb: IItem
    {
        public Vector2 position;

        ISprite sprite;

        public Bomb(Vector2 position, int frames)
        {
            this.position = position;
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(new BombAnimation());
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update()
        {
            sprite.Update();
        }
    }
}
