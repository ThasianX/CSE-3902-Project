using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;
using Microsoft.Xna.Framework.Media;

namespace Project1
{
    class SoundManager
    {
        private Dictionary<string, Song> loadedSongs = new Dictionary<string, Song>();

        private Dictionary<string, SoundEffect> loadedSounds = new Dictionary<string, SoundEffect>();

        private static SoundManager instance = new SoundManager();

        public static SoundManager Instance
        {
            get
            {
                return instance;
            }
        }

        public SoundManager()
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.25f;
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
                //Bug where DungeonTheme is included and is .mp3 file
                string fileName = file.Name.Split('.')[0].ToString();
                if (fileName != "DungeonTheme" && fileName != "Game Over" && fileName != "zelda_them_snes-cut-mp3")
                {
                    loadedSounds.Add(file.Name.Split('.')[0].ToString(), content.Load<SoundEffect>("SoundEffects/" + file.Name.Split('.')[0]));
                }                
            }
            loadedSongs.Add("ZeldaTheme", content.Load<Song>("zelda_theme_snes-cut-mp3"));
            loadedSongs.Add("DungeonTheme", content.Load<Song>("DungeonTheme"));
            loadedSongs.Add("GameOver", content.Load<Song>("Game Over"));

            MediaPlayer.Play(loadedSongs["DungeonTheme"]);
        }

        public SoundEffect GetSound(string soundName)
        {
            return loadedSounds[soundName];
        }

        public void PlayGameWinMusic()
        {
            MediaPlayer.Play(loadedSongs["ZeldaTheme"]);
        }

        public void PlayDungeonMusic()
        {
            MediaPlayer.Play(loadedSongs["DungeonTheme"]);
        }

        public void PlayGameOverMusic()
        {
            MediaPlayer.Play(loadedSongs["GameOver"]);
        }
    }
}