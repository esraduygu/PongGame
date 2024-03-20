using Core;
using UnityEngine;

namespace Score
{
   public class ScoreManager : MonoBehaviour
   {
      [SerializeField] private UIManager uiManager;
      [SerializeField] private Ball.Ball ball;
      [SerializeField] private int playerOneScore;
      [SerializeField] private int playerTwoScore;
   
      public void PlayerScored(int playerNumber)
      {
         if (playerNumber == 1)
         {
            playerOneScore++;
            uiManager.UpdateScoreText(playerNumber, playerOneScore);
            ball.ResetPosition();
         }
         else if (playerNumber == 2)
         {
            playerTwoScore++;
            uiManager.UpdateScoreText(playerNumber, playerTwoScore);
            ball.ResetPosition();
         }
      }
      
      // public void ResetScore(int playerNumber)
      // {
      //    playerOneScore = 0;
      //    playerTwoScore = 0;
      //    uiManager.UpdateScoreText(1, playerOneScore);
      //    uiManager.UpdateScoreText(2, playerTwoScore);
      // }
   }
}
