using UnityEngine;

namespace Ball
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject ballPrefab;
        private void Update()
        {
            SpawnBall();
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