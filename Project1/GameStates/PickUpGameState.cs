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
        private IInventoryItem itemRef;
        
        public PickUpGameState(Game1 game, IPlayer player, IInventoryItem item)
        {
            this.game = game;
            this.player = player;
            this.itemRef = item;
            GameObjectManager.Instance.RemoveImmediate(item);
            sprite = itemRef.Sprite;
            player.State = new PickUpPlayerState(player);
            offset.Y = -sprite.GetDimensions().height;
            offset.X = (player.Sprite.GetDimensions().width / 2) - (itemRef.Sprite.GetDimensions().width / 2);

            MediaPlayer.Pause();
            SoundManager.Instance.PlaySound("Fanfare");          
        }
        public void Update(GameTime gameTime, ArrayList controllerList)
        {
            if (timer > 1.5 && itemRef.Name.Equals("Triforce"))
            {
                game.gameState = new GameWinState(game);
            }
            else if (timer > 2)
            {
                game.gameState = new PlayingGameState(game);
                player.State = new StillPlayerState(player);
                MediaPlayer.Resume();
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
