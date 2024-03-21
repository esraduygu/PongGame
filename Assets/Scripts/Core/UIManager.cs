using System;
using TMPro;
using UnityEngine;

namespace Core
{
    public class UIManager : MonoBehaviour
    {
        public Action OnStartGame;
        
        public TMP_Text playerOneScoreText;
        public TMP_Text playerTwoScoreText;
        public TMP_Text winText;
        public TMP_Text playModeButtonText;
        public GameObject menuObject;

        [SerializeField] private GameManager gameManager;
        
        public void OnStartGameButtonClicked()
        {
            menuObject.SetActive(false);
            OnStartGame?.Invoke();
        }
        
        public void UpdateScoreText(int playerNumber, int score)
        {
            var scoreText = playerNumber == 1 ? playerOneScoreText : playerTwoScoreText;
            scoreText.text = score.ToString();
        }
        
        public void OnGameEnds(int winnerID)
        {
            menuObject.SetActive(true);
            winText.text = $"Player {winnerID} wins!";
        }

        public void OnSwitchModeClicked()
        {
            gameManager.SwitchPlayMode();
            AdjustPlayButtonText();
        }

        private void AdjustPlayButtonText()
        {
            switch (gameManager.playMode)
            {
                case GameManager.PlayMode.PlayerVsPlayer:
                    playModeButtonText.text = "2 Players";
                    break;

                case GameManager.PlayMode.PlayerVsAi:
                    playModeButtonText.text = "Player vs AI";
                    break;

            }
        }
    }
}
    
