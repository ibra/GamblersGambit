using System.Collections.Generic;
using Casino.Enemies.Slot;
using UnityEngine;

namespace Casino.Enemies
{
    public class EnemyManager : MonoBehaviour
    {
        private Rigidbody2D _rb;

        public static List<Enemy> Enemies { get; } = new List<Enemy>();
        public static bool EnemiesActive;

        private void Update()
        {
        }

        public static void AwakeAllEnemies()
        {
            foreach (Enemy enemy in Enemies)
            {
                (enemy as InactiveEnemy)?.TakeDamage(2f);
            }
        }
    }
}
