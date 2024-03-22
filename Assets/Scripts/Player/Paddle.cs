using Core;
using UnityEngine;

namespace Player
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Ball.Ball ball;
        [SerializeField] private PaddleDrag paddleDrag;
        [SerializeField] private KeyCode upKey;
        [SerializeField] private KeyCode downKey;
        [SerializeField] private float speed;
        [SerializeField] private float yLimit;
        [SerializeField] private float aiDeadZone = 1f;
        [SerializeField] private int paddleId;

        private float _delta;
        private float _posBeforeFrame;

        private void Awake()
        {
            paddleDrag.OnDrag = OnPaddleDrag;
        }

        private void OnEnable()
        {
            gameManager.OnGameEnds += _ => ResetAndDisable();
        }
        
        private void ResetAndDisable()
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            enabled = false;
        }

        private void OnPaddleDrag(float delta)
        {
            if (!enabled)
                return;
            _delta += delta;
        }
        
        private void Update()
        {
            _posBeforeFrame = transform.position.y;

            if (paddleId == 2 && gameManager.IsPlayerTwoAi())
                MoveAI();
            else
                PlayerMove();
        }
        
        private void LateUpdate()
        {
            if (gameManager.IsPlayerTwoAi())
            {
                _delta = 0f;
                return;
            }

            MoveByDelta();

            var delta = Mathf.Abs(_posBeforeFrame - transform.position.y);
            if (delta > (speed * Time.deltaTime) + 0.01f)
                Debug.Log($"Delta this frame: {delta} Limit: {speed * Time.deltaTime}");
        }

        private void MoveAI()
        {
            var direction = 0;
            var ballPos = ball.transform.position;

            if (Mathf.Abs(ballPos.y - transform.position.y) > aiDeadZone)
            {
                direction = ballPos.y > transform.position.y ? 1 : -1;
            }
            
            PaddleMove(direction);
        }
        
        private void PlayerMove()
        {
            var moveDirection = 0f;

            if (Input.GetKey(upKey) && transform.position.y < yLimit)
                moveDirection = 1f;
            else if (Input.GetKey(downKey) && transform.position.y > -yLimit) 
                moveDirection = -1f;

            PaddleMove(moveDirection);
        }

        private void PaddleMove(float moveDirection)
        {
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
        
        private void OnDisable()
        {
            gameManager.OnGameEnds -= _ => ResetAndDisable();
        }
    }
}

