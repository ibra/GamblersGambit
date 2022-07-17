using Casino.Bullets;
using Casino.Player;
using UnityEngine;

namespace Casino
{
    public class RouletteBullet : Bullet
    {
        protected override void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log($"{col.name} >> {col.tag}");
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
