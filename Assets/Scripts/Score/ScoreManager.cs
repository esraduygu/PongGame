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
      [SerializeField] public int maxScore;
   
      public void PlayerScored(int id)
      {
         if (id == 1)
         {
            playerOneScore++;
            uiManager.UpdateScoreText(1, playerOneScore);
            ball.ResetPosition();
         }
         else if (id == 2)
         {
            playerTwoScore++;
            uiManager.UpdateScoreText(2, playerTwoScore);
            ball.ResetPosition();
         }
         CheckWin();
      }

      private void CheckWin()
      {
         var winnerID = playerOneScore == maxScore ? 1 : playerTwoScore == maxScore ? 2 : 0;

         if (winnerID != 0)
         {
            uiManager.OnGameEnds(winnerID);
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
