using UnityEngine;
using Random = UnityEngine.Random;

namespace Ball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float speed;
        
        private void Start()
        {
            ResetPosition();
        }
        
        public void ResetPosition()
        {
            rb.position = Vector2.zero;
            rb.velocity = Vector2.zero;
            
            Invoke(nameof(Launch), 0.5f);
        }
        
        private void Launch()
        {
            var x = Random.value < 0.5f ? -1f : 1f;
            var y = Random.value < 0.5f ? Random.Range(-1f, -.5f) : Random.Range(.5f, 1f);

            var direction = new Vector2(x, y);
            rb.AddForce(direction * speed);
        }

    }
}
