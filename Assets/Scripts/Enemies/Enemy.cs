using System;
using UnityEngine;

namespace Casino.Enemies
{
    public class Enemy : MonoBehaviour
    {
        protected float _health;

        [SerializeField] protected float maxHealth;

        private void Awake()
        {
            _health = maxHealth;
            EnemyManager.Enemies.Add(this);
        }

        public virtual void Die()
        {
            EnemyManager.Enemies.Remove(this);
        }

        public virtual void TakeDamage(float damage)
        {
          
        }
    }
}
