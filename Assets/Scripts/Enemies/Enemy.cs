using System;
using UnityEngine;

namespace Casino.Enemies
{
    public class Enemy : MonoBehaviour
    {
        protected float Health;
        protected GameObject Player;
        
        [SerializeField] protected float damage;
        [SerializeField] protected float maxHealth;

        protected virtual void Awake()
        {
            Health = maxHealth;
        }

        protected virtual void Start()
        {
            Player = GameObject.FindWithTag("Player");
            EnemyManager.Enemies.Add(this);
        }

        public virtual void Die()
        {
            EnemyManager.Enemies.Remove(this);
            Destroy(gameObject);
        }

        public virtual void TakeDamage(float damage)
        {
            Health -= damage;
            if(Health <= 0)
                Die();
        }
    }
}
