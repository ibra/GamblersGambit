using Casino.Enemies;
using Unity.Mathematics;
using UnityEngine;

namespace Casino
{
    public class ActiveRouletteEnemy : Enemy
    {
        private float _currentShootingCooldown;
        
        [SerializeField] private float maximumShootingCooldown;
        [SerializeField] private GameObject projectile;

        protected override void Start()
        {
            base.Start();
            _currentShootingCooldown = maximumShootingCooldown / 2;
        }

        private void Update()
        {
            _currentShootingCooldown -= Time.deltaTime;
            if (_currentShootingCooldown <= 0)
            {
                Vector3 difference = Player.transform.position - transform.position;
                float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 270f;
                Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, rotation)));
                _currentShootingCooldown = maximumShootingCooldown;
            }
        }
    }
}
