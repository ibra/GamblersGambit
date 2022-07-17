using UnityEngine;

namespace Casino.Enemies.Slot
{
    public class ActiveSlotEnemy : Enemy
    {
        private GameObject _player;
        
        [SerializeField] private float damage;
        private Rigidbody2D _rb;
        [SerializeField] private float speed = 5f;


        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _player = GameObject.FindWithTag("Player");
        }

        private void FixedUpdate()
        {
            Vector2 direction = new Vector2(_player.transform.position.x - transform.position.x, _player.transform.position.y - transform.position.y);
            _rb.MovePosition((Vector2)transform.position + direction.normalized * Time.deltaTime * speed);
        }

        public override void TakeDamage(float damage)
        {
            _health -= damage;
            if(_health <= 0)
                Die();
        }

        public override void Die()
        {
            EnemyManager.Enemies.Remove(this);
            Destroy(gameObject);
        }
    }
}
