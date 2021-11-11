

namespace Project1
{
    class GameStateManager
    {
        private static GameStateManager instance = new GameStateManager();
        public static GameStateManager Instance
        {
            get
            {
                return instance;
            }
        }

        private GameState gameState;

        public GameState GetGameState()
        {
            return gameState;
        }

        public void SetGameOverGameState()
        {
            gameState = GameState.GameOver;
        }
    }
}
