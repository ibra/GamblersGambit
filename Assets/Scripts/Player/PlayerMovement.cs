using UnityEngine;

namespace Casino.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Animator _animator;

        [SerializeField] private PlayerGun gun;
        [SerializeField] private float speed;

        private Vector2 _input;
        private Vector2 _lastDirection = Vector2.zero;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            ReadInput();
            UpdateAnimator();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void ReadInput()
        {
            _input = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            ).normalized;
        }

        private void Move()
        {
            _rb.MovePosition(_rb.position + _input * speed * Time.fixedDeltaTime);
        }

        //private void UpdateAnimator()
        //{

        //    if (_input != Vector2.zero)
        //        _lastDirection = _input;

        //    _animator.SetFloat("MoveX", _lastDirection.x);
        //    _animator.SetFloat("MoveY", _lastDirection.y);
        //    _animator.SetFloat("Speed", _input.sqrMagnitude);
        //}

        private void UpdateAnimator()
        {
            Vector2 facing = gun.AimDirection;

            _animator.SetFloat("MoveX", facing.x);
            _animator.SetFloat("MoveY", facing.y);
            _animator.SetFloat("Speed", _input.sqrMagnitude);
        }
    }
}