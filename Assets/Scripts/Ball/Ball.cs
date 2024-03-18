using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private GameObject ballPrefab;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float speed;
        
        private void Start()
        {
            Launch();
        }

        private void Update()
        {
            SpawnBall();
        }

        private void Launch()
        {
            var x = Random.Range(1, -1f);
            var y = Random.Range(1, -1f);

            rb.velocity = new Vector2(speed * x, speed * y);
        }
        
        private void SpawnBall()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            }
        }

    }
}
