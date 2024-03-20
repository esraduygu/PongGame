using System;
using TMPro;
using UnityEngine;

namespace Core
{
    public class UIManager : MonoBehaviour
    {
        public TMP_Text playerOneScoreText;
        public TMP_Text playerTwoScoreText;
        public TMP_Text winText;
        public GameObject menuObject;

        public Action OnStartGame;

        public void UpdateScoreText(int playerNumber, int score)
        {
            var scoreText = playerNumber == 1 ? playerOneScoreText : playerTwoScoreText;
            scoreText.text = score.ToString();
        }

        public void OnStartGameButtonClicked()
        {
            menuObject.SetActive(false);
            OnStartGame?.Invoke();
        }

        public void OnGameEnds(int winnerID)
        {
            menuObject.SetActive(true);
            winText.text = $"Player {winnerID} wins!";
        }
    }
}
