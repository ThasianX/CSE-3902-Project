using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class AnimatedDynamicSpriteCommand : ICommand
    {
        public ISprite[] HideSprites { get; set; }

        public AnimatedDynamicSprite VisibleSprite { set; get; }

        public AnimatedDynamicSpriteCommand(AnimatedDynamicSprite sprite, ISprite[] hideSprites)
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

            VisibleSprite.xOffset = 0;
            VisibleSprite.Visible = true;

        }
    }
}
