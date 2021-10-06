using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class CyclableItem : IItem
    {
        public Vector2 position { get; set; }
        
        private int cycle;
        private int lastCycle;

        ISprite itemSprite;

        public CyclableItem(Vector2 pos)
        {
            cycle = 0;
            this.position = pos;
            this.itemSprite = SpriteFactory.Instance.CreateTileSprite(new WoodArrowUp());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            itemSprite.Draw(spriteBatch, this.position);
        }

        public void Update()
        {
            if (cycle != lastCycle)
            {
                switch (cycle)
                {
                    case 0:
                        this.itemSprite = SpriteFactory.Instance.CreateTileSprite(new WoodArrowUp());
                        break;
                    case 1:
                        this.itemSprite = SpriteFactory.Instance.CreateTileSprite(new KeySprite());
                        break;
                    case 2:
                        this.itemSprite = SpriteFactory.Instance.CreateTileSprite(new YellowRubySprite());
                        break;
                    case 3:
                        this.itemSprite = SpriteFactory.Instance.CreateTileSprite(new BlueRubySprite());
                        break;
                    case 4:
                        this.itemSprite = SpriteFactory.Instance.CreateAnimatedSprite(new FlashingRubyAnimation());
                        break;
                    case 5:
                        this.itemSprite = SpriteFactory.Instance.CreateAnimatedSprite(new HeartAnimation());
                        break;
                    case 6:
                        this.itemSprite = SpriteFactory.Instance.CreateAnimatedSprite(new TriforceAnimation());
                        break;
                    default:
                        this.itemSprite = SpriteFactory.Instance.CreateTileSprite(new WoodArrowUp());
                        break;
                }
            }
            itemSprite.Update();
            lastCycle = cycle;
        }

        public void CycleLeft()
        {
            if (cycle == 0){
                cycle = 6;
            }
            else
            {
                cycle--;
            }
        }
        public void CycleRight()
        {
            if (cycle == 6)
            {
                cycle = 0;
            }
            else
            {
                cycle++;
            }
        }
    }
}
