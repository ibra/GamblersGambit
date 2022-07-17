using Casino.Enemies;
using UnityEngine;

namespace Casino.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] public float damage = 5f;
        [SerializeField] public float speed;

        protected virtual void OnEnable()
        {
            Destroy(gameObject, 5f);
        }

        protected virtual void Update()
        {
            transform.position += transform.up * (speed * Time.deltaTime);
        }

        protected virtual void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
            if(col.CompareTag("Obstructive"))
                Destroy(gameObject);
        }
    }
}
