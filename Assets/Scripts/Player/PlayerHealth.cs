using UnityEngine;

namespace Casino.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        private float _health;

        [SerializeField] private float maxHealth = 30f;

        private void Start()
        {
            _health = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
        }
    }
}
