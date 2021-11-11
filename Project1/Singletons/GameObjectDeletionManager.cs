using Project1.Enemy;
using Project1.Interfaces;
using Project1.Levels;

namespace Project1
{
    public class GameObjectDeletionManager
    {
        private static GameObjectDeletionManager instance = new GameObjectDeletionManager();

        public static GameObjectDeletionManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void EnemyDeletionCheck(IEnemy enemy, IHealthState enemyHealth)
        {
            if (enemyHealth.health <= 0)
            {
                LevelManager.Instance.GetCurrentRoom().RemoveObject(enemy);
                GameObjectManager.Instance.RemoveOnNextFrame(enemy);
            }
        }

        public void GameOverCheck(IPlayer player, IHealthState playerHealth)
        {
            if (playerHealth.health <= 0)
            {
                GameStateManager.Instance.SetGameOverGameState();
            }
        }

    }


}
