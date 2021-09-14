using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class StaticSpriteCommand : ICommand
    {
        public ISprite[] HideSprites { get; set; }

        public StaticSprite VisibleSprite { set; get; }

        public StaticSpriteCommand(StaticSprite sprite, ISprite[] hideSprites)
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
