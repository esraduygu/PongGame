using System;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public PlayMode playMode;
        public Action OnModeChange;
        
        public enum PlayMode
        {
            PlayerVsPlayer,
            PlayerVsAi
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
