using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using Project1.Sprites;

namespace Project1
{
    class SpriteFactory
    {
        XDocument spriteData;

        private readonly string[] spritesheetFileNames =
        {
            // put the file names of spritesheets to load here
            "link_spritesheet",
            "smb_enemies_sheet",
            "dungeon_sheet",
            "item_spritesheet",
            "enemies",
            "bosses",
            "characters",
            "Enemy and Projectile"
        };

        private readonly string[] fontNames =
        {
            "Name",
        };

        private Dictionary<string, Texture2D> loadedTextures = new Dictionary<string, Texture2D>();
        private Dictionary<string, SpriteFont> loadedFonts = new Dictionary<string, SpriteFont>();

        private static SpriteFactory instance = new SpriteFactory();

        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public ISprite CreateAnimatedSprite(string xpath)
        {
            // get the spritesheet associated with the animation
            //Texture2D spritesheet = loadedTextures[animation.SpritesheetFileName];

            //System.Console.WriteLine(spriteData);
            //System.Console.WriteLine(spriteData.Element("sprite_data").Element("players"));

            XElement spriteNode = spriteData.Element("sprite_data").Element("players").Element("link").Element("walking").Element("up").Element("sprite");

            System.Console.WriteLine(spriteNode);

            string spritesheetFileName = spriteNode.Element("spritesheet").Value;

            Texture2D texture;
            if (!loadedTextures.TryGetValue(spritesheetFileName, out texture))
            {
                // throw texture not loaded exception
            }

            (int height, int width) dimensions;
            // get the height of the sprite
            dimensions.height = int.Parse(spriteNode.Element("height").Value);

            // get the width of the sprite
            dimensions.width = int.Parse(spriteNode.Element("width").Value);

            // get the length of the animation in seconds
            float time = float.Parse(spriteNode.Element("time").Value);

            // list of (int x, int y) tuples that specify the source location
            List<(int x, int y)> sources = new List<(int x, int y)>();
            foreach (XElement source in spriteNode.Elements("source"))
            {
                // get x
                int x = int.Parse(source.Element("x").Value);

                //get y
                int y = int.Parse(source.Element("y").Value);

                sources.Add((x, y));
            }

            return new AnimatedSprite(texture, dimensions, sources.ToArray(), time);
        }

        public ISprite CreateAnimatedSprite(IAnimation animation)
        {
            return null;
        }

        public ISprite CreateTileSprite(ITileData tileSprite)
        {
            Texture2D spritesheet = loadedTextures[tileSprite.SpritesheetFileName];

            return new TileSprite(spritesheet, tileSprite.Source);
        }

        public ISprite CreateHealthSprite(IHealthState healthState, string fontName)
        {
            SpriteFont font = loadedFonts[fontName];

            return new HealthSprite(font, healthState);
        }

        public void LoadSpriteData(string path)
        {
            spriteData = XDocument.Load(path);

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

        public void LoadAllFonts(ContentManager content)
        {
            // Load each spritesheet and store it in a dictionary with the file name
            // This allows animations to be tied to a specific spritesheet
            foreach (string fontName in fontNames)
            {
                loadedFonts.Add(fontName, content.Load<SpriteFont>(fontName));
            }
        }
    }
}
