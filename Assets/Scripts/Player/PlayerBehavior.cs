using UnityEngine;

namespace Player
{
    public class PlayerBehavior : MonoBehaviour
    {
        [SerializeField] private KeyCode upKey;
        [SerializeField] private KeyCode downKey;
        [SerializeField] private float speed;
        [SerializeField] private float yLimit;

        private float _moveDirection;
      

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (Input.GetKey(upKey) && transform.position.y < yLimit)
            {
                _moveDirection = 1f;
            }
            else if (Input.GetKey(downKey) && transform.position.y > -yLimit)
            {
                _moveDirection = -1f;
            }
            
            transform.Translate(Vector3.up * (_moveDirection * speed * Time.deltaTime));
        }

        private void OnMouseDrag()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            mousePosition.y = Mathf.Clamp(mousePosition.y, -yLimit, yLimit);
            
            transform.position = new Vector3(transform.position.x, mousePosition.y, transform.position.z);
            
        }
    }
}

