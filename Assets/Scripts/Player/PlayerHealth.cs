using UnityEngine;
using UnityEngine.UI;

namespace Casino.Player
{

    
    public class PlayerHealth : MonoBehaviour
    {
        private float _health;

        [SerializeField] private Image healthBar;
        [SerializeField] private float maxHealth = 30f;
        
        private void Start()
        {
            _health = maxHealth;
            healthBar.fillAmount = _health / maxHealth;
        }
        

        public void TakeDamage(float damage)
        {
            _health -= damage;
            healthBar.fillAmount = _health / maxHealth;
            if (_health <= 0)
                Die();
        }

        private void Die()
        {
           Debug.Log("Dead");
        }
    }
}
