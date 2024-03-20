using TMPro;
using UnityEngine;

namespace Core
{
    public class UIManager : MonoBehaviour
    {
        public TMP_Text playerOneScoreText;
        public TMP_Text playerTwoScoreText;
        
        public void UpdateScoreText(int playerNumber, int score)
        {
            var scoreText = playerNumber == 1 ? playerOneScoreText : playerTwoScoreText;
            scoreText.text = score.ToString();
        }
    }
}
