using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class CyclableItem
    {
        private int cycle;
        private int lastCycle;

        ISprite itemSprite;

        public CyclableItem()
        {
            cycle = 0;
            this.itemSprite = SpriteFactory.Instance.CreateStillSprite(new VerticalWoodArrow());
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            itemSprite.Draw(spriteBatch, location);
        }

        public void Update()
        {
            if (cycle != lastCycle)
            {
                switch (cycle)
                {
                    case 0:
                        this.itemSprite = SpriteFactory.Instance.CreateStillSprite(new VerticalWoodArrow());
                        break;
                    case 1:
                        this.itemSprite = SpriteFactory.Instance.CreateStillSprite(new KeyItem());
                        break;
                    case 2:
                        this.itemSprite = SpriteFactory.Instance.CreateStillSprite(new YellowRubyItem());
                        break;
                    case 3:
                        this.itemSprite = SpriteFactory.Instance.CreateStillSprite(new BlueRubyItem());
                        break;
                    case 4:
                        this.itemSprite = SpriteFactory.Instance.CreateAnimatedSprite(new FlashingRubyItem());
                        break;
                    case 5:
                        this.itemSprite = SpriteFactory.Instance.CreateAnimatedSprite(new HeartItem());
                        break;
                    case 6:
                        this.itemSprite = SpriteFactory.Instance.CreateAnimatedSprite(new TriforceItem());
                        break;
                    default:
                        this.itemSprite = SpriteFactory.Instance.CreateStillSprite(new VerticalWoodArrow());
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
