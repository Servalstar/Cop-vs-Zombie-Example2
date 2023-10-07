using Services.SaveLoad;
using Services.SaveLoad.Contracts;
using UI.Windows.Presenters;
using UnityEngine.SceneManagement;

namespace UI.MainMenu
{
    public class MainMenuPresenter : BaseWindowPresenter<MainMenuUI>
    {
        private readonly ISaver _saver;
        private const string GAME_SCENE_NAME = "Game";

        public MainMenuPresenter(ISaver saver)
        {
            _saver = saver;
        }

        public override void Open()
        {
            var score = _saver.Load<PlayerProgress>().BestResult;
            _view.Initialize(score, StartGame);
            base.Open();
        }

        private void StartGame()
        {
            SceneManager.LoadScene(GAME_SCENE_NAME);
        }
    }
}