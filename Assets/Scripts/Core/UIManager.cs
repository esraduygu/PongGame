using TMPro;
using UnityEditor;
using UnityEngine;

namespace Core
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GameObject menuObject;
        [SerializeField] private TMP_Text playerOneScoreText;
        [SerializeField] private TMP_Text playerTwoScoreText;
        [SerializeField] private TMP_Text winText;
        [SerializeField] private TMP_Text playModeButtonText;

        private void Awake()
        {
            gameManager.OnGameEnds += ShowWinnerText;
        }

        private void OnStartGameButtonClicked()
        {
            menuObject.SetActive(false);
            gameManager.StartGame();
        }
        
        private void ShowWinnerText(int winnerID)
        {
            menuObject.SetActive(true);
            winText.text = $"Player {winnerID} wins!";
        }
        
        public void UpdateScoreText(int playerNumber, int score)
        {
            var scoreText = playerNumber == 1 ? playerOneScoreText : playerTwoScoreText;
            scoreText.text = score.ToString();
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
        
        public void OnExitButtonClicked()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#elif UNITY_STANDALONE_WIN
            Application.Quit();
#endif
        }
    }
}
    
