using System;
using UnityEngine;
using UnityEngine.UI;

namespace Casino.Player
{

    
    public class PlayerHealth : MonoBehaviour
    {
        private float _health;
        private HeartHealth[] healthImages;

        [SerializeField] private GameObject healthBar;
        [SerializeField] private float maxHealth = 30f;
        
        private void Start()
        {
            _health = maxHealth;
            healthImages = healthBar.GetComponentsInChildren<HeartHealth>();
        }

        private void Update()
        {
            for (int i = 0; i < healthImages.Length; i++)
            {
                int heartStatusRemainder = (int)Mathf.Clamp(_health - (i * 4), 0, 4);
                healthImages[i].SetHeart((HeartType)heartStatusRemainder);
            }
        }



        public void TakeDamage(float damage)
        {
            Debug.Log(damage);
            _health -= damage;

            if (_health <= 0)
                Die();
        }

        private void Die()
        {
           Debug.Log("Dead");
        }
    }
}
