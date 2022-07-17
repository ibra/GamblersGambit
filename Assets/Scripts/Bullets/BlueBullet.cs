using System;
using Casino.Enemies;
using UnityEngine;

namespace Casino.Bullets
{
    public class BlueBullet : Bullet
    {
        private bool _doingSplash; 
        
        [SerializeField] private float lifetime = 2f;
        
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
            transform.Find("aoe").gameObject.SetActive(true);
            Collider2D[] collidedObjects = Physics2D.OverlapCircleAll((Vector2)transform.position, 1.5f);
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
