using Services.SaveLoad;
using Services.SaveLoad.Contracts;
using UnityEngine.SceneManagement;

namespace UI.MainMenu
{
    public class MainMenuPresenter
    {
        private const string GAME_SCENE_NAME = "Game";

        public void SetView(MainMenuUI view, ISaver saver)
        {
            var score = saver.Load<PlayerProgress>().BestResult;
            view.Initialize(score, StartGame);
        }
    
        private void StartGame()
        {
            SceneManager.LoadScene(GAME_SCENE_NAME);
        }
    }
}