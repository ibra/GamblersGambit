using System;
using Casino.Player;
using UnityEngine;

namespace Casino.Enemies.Slot
{
    public class ActiveSlotEnemy : Enemy
    {
        private Rigidbody2D _rb;
        [SerializeField] private float speed = 5f;

        private void FixedUpdate()
        {
            Vector2 direction = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
            _rb.MovePosition((Vector2)transform.position + direction.normalized * Time.deltaTime * speed);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                Player.GetComponent<PlayerHealth>().TakeDamage(damage);
                Die();
            }
        }
    }
}
