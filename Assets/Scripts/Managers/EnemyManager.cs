using System;
using System.Collections.Generic;
using UnityEngine;

namespace Casino.Enemies
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        
        public static List<Enemy> Enemies { get; } = new List<Enemy>();

        public static void AddEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
        }

        private void Update()
        {
            _direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        }
    }
}
