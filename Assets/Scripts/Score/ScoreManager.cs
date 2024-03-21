using Core;
using UnityEngine;

namespace Score
{
   public class ScoreManager : MonoBehaviour
   {
      [SerializeField] private GameManager gameManager;
      [SerializeField] private UIManager uiManager;
      [SerializeField] private SfxManager sfxManager;
      [SerializeField] private Ball.Ball ball;
      
      [SerializeField] private int playerOneScore;
      [SerializeField] private int playerTwoScore;
      [SerializeField] public int maxScore;

      private void Awake()
      {
         gameManager.OnStartGame += OnStartGame;
      }

      private void OnStartGame()
      {
         ResetScore();
         
         uiManager.UpdateScoreText(1, playerOneScore);
         uiManager.UpdateScoreText(2, playerTwoScore);
      }

      public void PlayerScored(int id)
      {
         if (id == 1)
         {
            playerOneScore++;
            uiManager.UpdateScoreText(1, playerOneScore);
         }
         else if (id == 2)
         {
            playerTwoScore++;
            uiManager.UpdateScoreText(2, playerTwoScore);
         }

         CheckWin();
      }

      private void CheckWin()
      {
         var winnerID = playerOneScore == maxScore ? 1 : playerTwoScore == maxScore ? 2 : 0;

         if (winnerID != 0)
         {
            gameManager.EndGame(winnerID);
            sfxManager.PlaySound(SfxManager.SfxType.Win);
         }
         else
            ball.ResetPosition();
      }

      private void ResetScore()
      {
         playerOneScore = 0;
         playerTwoScore = 0;
      }
   }
}
