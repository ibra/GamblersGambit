using System;
using System.Collections.Generic;
using Casino.Enemies.Slot;
using UnityEngine;

namespace Casino.Enemies
{
    public class EnemyManager : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [SerializeField] private Barrier barrier;
        public static List<Enemy> Enemies { get; } = new List<Enemy>();

        private void Update()
        {
            if(!barrier.isOpen)
                barrier.Open();
        }

        public static void AwakeAllEnemies()
        {
            foreach (Enemy enemy in Enemies)
            {
                InactiveEnemy inactiveEnemy = enemy as InactiveEnemy;
                if(inactiveEnemy != null)
                    inactiveEnemy.TakeDamage(2f);
            }
        }
    }
}
