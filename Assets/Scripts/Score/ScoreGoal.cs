using Core;
using UnityEngine;

namespace Score
{
    public class ScoreGoal : MonoBehaviour
    {
        [SerializeField] private SfxManager sfxManager;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private bool isLeftWall;
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Ball")) return;
            sfxManager.PlaySound(SfxManager.SfxType.Score);
            scoreManager.PlayerScored(isLeftWall ? 2 : 1);
        }
    }
}
