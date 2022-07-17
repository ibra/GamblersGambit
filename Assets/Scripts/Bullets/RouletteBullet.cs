using Casino.Bullets;
using Casino.Player;
using UnityEngine;

namespace Casino
{
    public class RouletteBullet : Bullet
    {
        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out PlayerHealth health))
            {
                health.TakeDamage(damage);
                Destroy(gameObject);
            }
            if(col.CompareTag("Obstructive"))
                Destroy(gameObject);
        }
    }
}
