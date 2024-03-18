using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [SerializeField] private float speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveDirection = 0;
        if (Input.GetKey(upKey))
        {
            moveDirection = -1f;
        }
        else if (Input.GetKey(downKey))
        {
            moveDirection = 1f;
        }
        
        transform.Translate(Vector3.up * (moveDirection * speed * Time.deltaTime));
    }
}
