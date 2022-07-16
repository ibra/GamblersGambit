using Casino.Enemies;
using UnityEngine;

namespace Casino.Combat
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float damage = 5f;
        [SerializeField] private float speed;

        private void OnEnable()
        {
            Destroy(gameObject, 3f); //TODO: remove this
        }

        private void Update()
        {
            transform.position += transform.up * (speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
            // if(col.CompareTag("Obstructive"))
            //     Destroy(gameObject);
        }
    }
}
