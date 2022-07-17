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
