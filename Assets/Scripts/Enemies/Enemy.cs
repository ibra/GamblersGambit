using System;
using UnityEngine;

namespace Casino.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private float _health;

        [SerializeField] private float maxHealth;

        private void Awake()
        {
            _health = maxHealth;
        }

        public virtual void Die()
        {
            
        }

        public virtual void TakeDamage()
        {
          
        }
    }
}
