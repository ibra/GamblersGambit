using System;
using Casino.Enemies;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Casino.Bullets
{
    public class BlueBullet : Bullet
    {
        private bool _doingSplash; 
        
        [SerializeField] private float lifetime = 2f;
        [SerializeField] private GameObject blueExplosion;

        protected override void Update()
        {
            if(!_doingSplash)
                transform.position += transform.up * (speed * Time.deltaTime);
        }
        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(damage);
                DoSplashDamage();
                Destroy(gameObject, lifetime);
            }
            if (col.CompareTag("Obstructive"))
            {
                DoSplashDamage();
                Destroy(gameObject, lifetime);
            }
            Destroy(gameObject,5f);
        }

        private void DoSplashDamage()
        {
            _doingSplash = true;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            var explosion = Instantiate(blueExplosion, transform.position, Quaternion.identity);
            Destroy(explosion, 0.5f);
            Collider2D[] collidedObjects = Physics2D.OverlapCircleAll(transform.position, 1.5f);
            foreach (Collider2D collider in collidedObjects)
            {
                if (collider.TryGetComponent(out Enemy splashEnemy))
                {
                    splashEnemy.TakeDamage(damage);
                }
            }
        }
    }
}
