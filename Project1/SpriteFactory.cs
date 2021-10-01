﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using Project1.Sprites;

namespace Project1
{
    class SpriteFactory
    {
        private readonly string[] spritesheetFileNames =
        {
            // put the file names of spritesheets to load here
            "link_spritesheet",
            "smb_enemies_sheet",
            "dungeon_sheet",
            "item_spritesheet",
            "enemies",
            "bosses",
            "characters"
        };

        private Dictionary<string, Texture2D> loadedTextures = new Dictionary<string, Texture2D>();

        private static SpriteFactory instance = new SpriteFactory();

        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public ISprite CreateAnimatedSprite(IAnimation animation)
        {
            // get the spritesheet associated with the animation
            Texture2D spritesheet = loadedTextures[animation.SpritesheetFileName];

            return new AnimatedSprite(spritesheet, animation);
        }

        public ISprite CreateTileSprite(ITileData tileSprite)
        {
            Texture2D spritesheet = loadedTextures[tileSprite.SpritesheetFileName];

            return new TileSprite(spritesheet, tileSprite.Source);
        }

        public void LoadAllTextures(ContentManager content)
        {
            // Load each spritesheet and store it in a dictionary with the file name
            // This allows animations to be tied to a specific spritesheet
            foreach (string fileName in spritesheetFileNames)
            {
                loadedTextures.Add(fileName, content.Load<Texture2D>(fileName));
            }

        }
    }
}
