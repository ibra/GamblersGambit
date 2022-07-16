using UnityEngine;

namespace Casino.Enemies.Slot
{
    public class ActiveSlotEnemy : Enemy
    {
        private GameObject _player;
        
        [SerializeField] private float damage;
     

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
           
        }
    }
}
