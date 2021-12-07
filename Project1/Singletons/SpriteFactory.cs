using System.Collections.Generic;
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
        XDocument spriteDictionary;

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
            "Enemy and Projectile",
            "zelda_UI",
            "TitleScreens",
            "HUDPauseScreen",
            "GunSheet"
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

        public ISprite CreateSprite(string spriteName)
        {
            // get the path corresponding to the spriteName
            string path = spriteDictionary.Root.Element(spriteName).Value;

            // split the path into tags
            string[] tags = path.Split('/');

            // start at the root of sprite_data
            XElement spriteNode = spriteData.Root;

            // traverse the path
            foreach(string tag in tags)
            {
                spriteNode = spriteNode.Element(tag);
            }

            // collect values ===============================================================================

            // get the spritesheet file name
            string spritesheetFileName = spriteNode.Element("spritesheet").Value;

            // find get the loaded texture of the spritesheet
            Texture2D texture;
            if (!loadedTextures.TryGetValue(spritesheetFileName, out texture))
            {
                System.Diagnostics.Debug.Print("Tried create sprite " + spriteName + " but the spritesheet "
                    + spritesheetFileName + " is not loaded.");
            }

            // get sprite dimensions
            Dimensions dimensions;
            dimensions.height = int.Parse(spriteNode.Element("dimensions").Element("height").Value);
            dimensions.width = int.Parse(spriteNode.Element("dimensions").Element("width").Value);

            // get the length of the animation in seconds
            double time = double.Parse(spriteNode.Element("time").Value);

            // list of (int x, int y) tuples that specify the source location
            List<(int x, int y)> sources = new List<(int x, int y)>();
            foreach (XElement source in spriteNode.Element("source_list").Elements("source"))
            {
                // get x
                int x = int.Parse(source.Element("x").Value);

                //get y
                int y = int.Parse(source.Element("y").Value);

                sources.Add((x, y));
            }

            // done collecting values =======================================================================

            // create the sprite
            return new AnimatedSprite(texture, dimensions, sources.ToArray(), time);
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

        public void loadSpriteDictionary(string path)
        {
            spriteDictionary = XDocument.Load(path);
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
