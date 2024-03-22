using Player;
using UnityEngine;

namespace Core
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Paddle playerOne;
        [SerializeField] private Paddle playerTwo;

        private void Awake()
        {
            gameManager.OnStartGame += EnablePlayers;
        }

        private void EnablePlayers()
        {
            playerOne.enabled = true;
            playerTwo.enabled = true;
        }
    }
}
