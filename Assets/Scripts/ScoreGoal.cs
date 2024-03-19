using UnityEngine;

public class ScoreGoal : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private bool isLeftWall;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            scoreManager.PlayerScored(isLeftWall ? 2 : 1);
        }
    }
}
