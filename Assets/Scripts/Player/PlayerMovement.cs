using UnityEngine;

namespace Casino.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Vector2 _movementVelocity;
    
        [SerializeField] private float speed;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _movementVelocity = moveInput * speed;
            _rb.MovePosition(_rb.position + _movementVelocity * Time.deltaTime);
        }
    }
}

