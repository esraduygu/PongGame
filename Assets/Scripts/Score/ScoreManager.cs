using TMPro;
using UnityEngine;

namespace Score
{
   public class ScoreManager : MonoBehaviour
   {
      [SerializeField] private TMP_Text playerOneScoreText;
      [SerializeField] private TMP_Text playerTwoScoreText;

      [SerializeField] private int playerOneScore;
      [SerializeField] private int playerTwoScore;
   
      public void PlayerScored(int playerNumber)
      {
         if (playerNumber == 1)
         {
            playerOneScore++;
            UpdateScoreText(playerOneScoreText, playerOneScore);
         }
         else if (playerNumber == 2)
         {
            playerTwoScore++;
            UpdateScoreText(playerTwoScoreText, playerTwoScore);
         }
      }
   
      private void UpdateScoreText(TMP_Text scoreText, int score)
      {
         scoreText.text = score.ToString();
      }
   
      public void ResetScore()
      {
         playerOneScore = 0;
         playerTwoScore = 0;
         UpdateScoreText(playerOneScoreText, playerOneScore);
         UpdateScoreText(playerTwoScoreText, playerTwoScore);
      }
   }
}
