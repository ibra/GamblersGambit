using System;
using UnityEngine;
using UnityEngine.UI;

namespace Casino.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        private float _health;
        private Image[] healthImages;

        [SerializeField] private GameObject healthBar;
        [SerializeField] private Image[] healthQuarters;
        [SerializeField] private float maxHealth = 30f;
        
        private void Start()
        {
            _health = maxHealth;
            healthImages = healthBar.GetComponentsInChildren<Image>();
        }

        private void Update()
        {
               
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
        }
    }
}
