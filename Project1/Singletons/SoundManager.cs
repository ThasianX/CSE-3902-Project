using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Project1
{
    class SoundManager
    {
        private Dictionary<string, SoundEffect> loadedSounds = new Dictionary<string, SoundEffect>();

        private static SoundManager instance = new SoundManager();

        public static SoundManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void PlaySound(string soundName)
        {
            loadedSounds[soundName].Play();
        }

        public void LoadAllSounds(ContentManager content)
        {
            DirectoryInfo dir = new DirectoryInfo(content.RootDirectory + "/SoundEffects");
            if (!dir.Exists)
                throw new DirectoryNotFoundException();

            FileInfo[] files = dir.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                loadedSounds.Add(file.ToString(), content.Load<SoundEffect>("SoundEffects/" + file.Name.Split('.')[0]));
            }
        }
    }
}