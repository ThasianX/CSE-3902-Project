using System.Collections.Generic;
using Project1.Enemy;
using Project1.Interfaces;
using Project1.PlayerStates;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1.Levels
{
    public class Room
    {
        private IGameObject floor;
        private IPlayer player;
        public Collection<IGameObject> gameObjects = new Collection<IGameObject>();
        private Collection<IEnemy> enemies = new Collection<IEnemy>();
        private Collection<IBlock> blocks = new Collection<IBlock>();
        private Collection<IItem> items = new Collection<IItem>();
        private Collection<IGameObject> walls = new Collection<IGameObject>();
        private Collection<IGameObject> doors = new Collection<IGameObject>();

        // MARK: Setters
        public void AddWall(IGameObject wall) {
            gameObjects.Add(wall);
            walls.Add(wall);
        }
        
        public void SetFloor(IGameObject floor) {
            this.floor = floor;
        }

        public void AddDoor(IGameObject door) {
            doors.Add(door);
            gameObjects.Add(door);
        }

        public void SetPlayer(IPlayer player) {
            this.player = player;
            gameObjects.Add(player);
        }

        public void AddEnemy(IEnemy enemy) {
            enemies.Add(enemy);
            gameObjects.Add(enemy);
        }
        
        public void AddBlock(IBlock block) {
            blocks.Add(block);
            gameObjects.Add(block);
        }
        
        public void AddItem(IItem item) {
            items.Add(item);
            gameObjects.Add(item);
        }


        // MARK: Getters
        public Collection<IGameObject> GetWalls()
        {
            return walls;
        }

        public IGameObject GetFloor()
        {
            return floor;
        }

        public Collection<IGameObject> GetDoors()
        {
            return doors;
        }

        public IPlayer GetPlayer()
        {
            return player;
        }

        public Collection<IEnemy> GetEnemies()
        {
            return enemies;
        }

        public Collection<IItem> GetItems()
        {
            return items;
        }

        // MARK: Removers
        public void RemoveEnemy(IEnemy enemy)
        {
            gameObjects.Remove(enemy);
            enemies.Remove(enemy);
        }

        public void RemoveItem(IItem item)
        {
            gameObjects.Remove(item);
            items.Remove(item);
        }

        // MARK: Instance methods
        public void Update(GameTime gameTime)
        {
            floor.Update(gameTime);
            foreach (IGameObject wall in walls)
            {
                wall.Update(gameTime);
            }
            foreach (IEnemy enemy in enemies)
            {
                enemy.Update(gameTime);
            }
            foreach (IBlock block in blocks)
            {
                block.Update(gameTime);
            }
            foreach (IItem item in items)
            {
                item.Update(gameTime);
            }
            foreach (IGameObject door in doors)
            {
                door.Update(gameTime);
            }
            player.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            floor.Draw(spriteBatch);
            foreach (IGameObject wall in walls)
            {
                wall.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IBlock block in blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach (IItem item in items)
            {
                item.Draw(spriteBatch);
            }
            foreach (IGameObject door in doors)
            {
                door.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
        }

        // MARK: Collision
        // return a list of ICollidable that is also a mover
        public List<ICollidable> GetMoverList()
        {
            List<ICollidable> movers = new List<ICollidable>();
            foreach (ICollidable obj in gameObjects)
            {
                if (obj.IsMover)
                {
                    movers.Add(obj);
                }
            }

            return movers;
        }

        // return a list of ICollidable that is not a mover
        public List<ICollidable> GetStaticList()
        {
            List<ICollidable> statics = new List<ICollidable>();
            foreach (ICollidable obj in gameObjects)
            {
                if (!obj.IsMover)
                {
                    statics.Add(obj);
                }
            }

            return statics;
        }
    }
}
