using System;
using TMPro;
using UI.Windows.Views;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu
{
    public class MainMenuUI : BaseView
    {
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private Button _startGameButton;
    
        private Action _onStartGame;

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(OnStartGame);
        }
    
        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(OnStartGame);
        }

        public void Initialize(int score, Action onStartGame)
        {
            _onStartGame = onStartGame;
            _score.text = "Best score: " + score;
        }

        private void OnStartGame()
        {
            _onStartGame?.Invoke();
        }
    }
}