using UnityEngine;

namespace Player
{
    public class PlayerBehavior : MonoBehaviour
    {
        [SerializeField] private PaddleDrag paddleDrag;
        [SerializeField] private KeyCode upKey;
        [SerializeField] private KeyCode downKey;
        [SerializeField] private int paddleId;
        [SerializeField] private float speed;
        [SerializeField] private float yLimit;

        private float _delta;
        private float _posBeforeFrame;

        private void Awake()
        {
            paddleDrag.OnDrag = OnPaddleDrag;
        }

        private void OnPaddleDrag(float delta)
        {
            _delta += delta;
        }
        
        private void Update()
        {
            _posBeforeFrame = transform.position.y;
            
            Move();
        }

        private void LateUpdate()
        {
            MoveByDelta();

            var delta = Mathf.Abs(_posBeforeFrame - transform.position.y);
            if (delta > (speed * Time.deltaTime) + 0.01f)
                Debug.Log($"Delta this frame: {delta} Limit: {speed * Time.deltaTime}");
        }
        
        private void Move()
        {
            var moveDirection = 0f;
            
            if (Input.GetKey(upKey) && transform.position.y < yLimit)
            {
                moveDirection = 1f;
            }
            else if (Input.GetKey(downKey) && transform.position.y > -yLimit)
            {
                moveDirection = -1f;
            }
            
            transform.Translate(Vector3.up * (moveDirection * speed * Time.deltaTime));
        }
        
        private void MoveByDelta()
        {
            var maxDelta = speed * Time.deltaTime;
            var limitedDelta = Mathf.Clamp(_delta, -maxDelta, maxDelta);
            var newPos = Mathf.Clamp(transform.position.y + limitedDelta, -yLimit, yLimit);
            
            transform.position = new Vector3(transform.position.x, newPos, transform.position.z);
            
            _delta -= limitedDelta;
        }
    }
}

