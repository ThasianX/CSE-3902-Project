using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class CyclableBlock : IBlock
    {
        private int cycle;
        private int lastCycle;

        ISprite blockSprite;

        public CyclableBlock()
        {
            cycle = 0;
            this.blockSprite = SpriteFactory.Instance.CreateTileSprite(new HorizontalWoodArrow());
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            blockSprite.Draw(spriteBatch, location);
        }

        public void Update()
        {
            if (cycle != lastCycle)
            {
                switch (cycle)
                {
                    case 0:
                        this.blockSprite = SpriteFactory.Instance.CreateTileSprite(new HorizontalWoodArrow());
                        break;
                    case 1:
                        this.blockSprite = SpriteFactory.Instance.CreateTileSprite(new PyramidBlock());
                        break;
                    case 2:
                        this.blockSprite = SpriteFactory.Instance.CreateTileSprite(new StairBlock());
                        break;
                    case 3:
                        this.blockSprite = SpriteFactory.Instance.CreateTileSprite(new BlackBlock());
                        break;
                    case 4:
                        this.blockSprite = SpriteFactory.Instance.CreateTileSprite(new StoneBlock());
                        break;
                    case 5:
                        this.blockSprite = SpriteFactory.Instance.CreateTileSprite(new LadderBlock());
                        break;
                    default:
                        this.blockSprite = SpriteFactory.Instance.CreateTileSprite(new HorizontalWoodArrow());
                        break;
                }
            }
            blockSprite.Update();
            lastCycle = cycle;
        }

        public void CycleLeft()
        {
            if (cycle == 0){
                cycle = 5;
            }
            else
            {
                cycle--;
            }
        }
        public void CycleRight()
        {
            if (cycle == 5)
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
