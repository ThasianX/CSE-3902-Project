using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Project1.Interfaces;
using Project1.PlayerStates;

namespace Project1.GameStates
{
    class PickUpGameState : IGameState
    {
        public Game1 game;
        public ISprite sprite;
        private double timer = 0;
        private IPlayer player;
        private Vector2 offset;
        
        public PickUpGameState(Game1 game, IPlayer player, IInventoryItem item)
        {
            this.game = game;
            this.player = player;
            sprite = item.Sprite;
            player.State = new PickUpPlayerState(player);
            offset.Y = -sprite.GetDimensions().height;
            offset.X = (player.Sprite.GetDimensions().width / 2) - (item.Sprite.GetDimensions().width / 2);

            MediaPlayer.Pause();
            SoundManager.Instance.PlaySound("Fanfare");
        }
        public void Update(GameTime gameTime, ArrayList controllerList)
        {
            if(timer > 2)
            {
                MediaPlayer.Resume();
                game.gameState = new PlayingGameState(game);
                player.State = new StillPlayerState(player);
            }
            timer += gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            GameObjectManager.Instance.DrawObjects(spriteBatch);

            sprite.Draw(spriteBatch, player.Position + offset);
        }
        public void Pause()
        {
            game.gameState = new PlayingGameState(game);
        }
        public void PickUp()
        {
        }
    }
}
