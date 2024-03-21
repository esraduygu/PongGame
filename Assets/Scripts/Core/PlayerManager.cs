using Player;
using UnityEngine;

namespace Core
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerBehavior playerOne;
        [SerializeField] private PlayerBehavior playerTwo;
        [SerializeField] private UIManager uiManager;
        
        private void Awake()
        {
            uiManager.OnStartGame += EnablePlayers;
        }

        private void EnablePlayers()
        {
            playerOne.enabled = true;
            playerTwo.enabled = true;
        }
    }
}
