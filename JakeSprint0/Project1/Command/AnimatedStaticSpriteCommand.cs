using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class AnimatedStaticSpriteCommand : ICommand
    {
        public ISprite[] HideSprites { get; set; }

        public AnimatedStaticSprite VisibleSprite { set; get; }

        public AnimatedStaticSpriteCommand(AnimatedStaticSprite sprite, ISprite[] hideSprites)
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

            VisibleSprite.Visible = true;

        }
    }
}
