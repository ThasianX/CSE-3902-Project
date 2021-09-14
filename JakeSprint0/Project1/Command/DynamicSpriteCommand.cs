using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class DynamicSpriteCommand : ICommand
    {
        public ISprite[] HideSprites { get; set; }

        public DynamicSprite VisibleSprite { set; get; }

        public DynamicSpriteCommand(DynamicSprite sprite, ISprite[] hideSprites)
        {
            VisibleSprite = sprite;
            HideSprites = hideSprites;

        }

        public void Execute()
        {
            foreach (ISprite sprite in HideSprites)
            {
                sprite.Visible = false;
            }

            VisibleSprite.yOffset = 0;
            VisibleSprite.Visible = true;

        }
    }
}
