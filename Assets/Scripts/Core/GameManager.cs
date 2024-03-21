using System;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public Action OnStartGame;
        public Action<int> OnGameEnds;
        public PlayMode playMode;
        public Action OnModeChange;
        
        public enum PlayMode
        {
            PlayerVsPlayer,
            PlayerVsAi
        }

        public void StartGame()
        {
            OnStartGame?.Invoke();
        }

        public void EndGame(int winnerID)
        {
            OnGameEnds?.Invoke(winnerID);
        }

        public void SwitchPlayMode()
        {
            switch (playMode)
            {
                case PlayMode.PlayerVsPlayer:
                    playMode = PlayMode.PlayerVsAi;
                    break;

                case PlayMode.PlayerVsAi:
                    playMode = PlayMode.PlayerVsPlayer;
                    break;
                
            }
            
            OnModeChange?.Invoke();
        }
        
        public bool IsPlayerTwoAi()
        {
            return playMode == PlayMode.PlayerVsAi;
        }
    }
}
