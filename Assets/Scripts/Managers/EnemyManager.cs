using System;
using System.Collections.Generic;
using UnityEngine;

namespace Casino.Enemies
{
    public class EnemyManager : MonoBehaviour
    {
        private Rigidbody2D _rb;

        public static List<Enemy> Enemies { get; } = new List<Enemy>();

        public static void AddEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
        }
    }
}
