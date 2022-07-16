using System.Collections;
using UnityEngine;

namespace Casino.Enemies.Slot
{
    public class InactiveSlotEnemy : Enemy
    {
        private bool _settingType;
        private Animator _animator;

        [SerializeField] private GameObject smokeObject;
        [SerializeField] private GameObject[] enemies;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public override void TakeDamage(float damage)
        {
            if (!_settingType)
            {
                StartCoroutine(SetEnemyType());
            }
        }

        private IEnumerator SetEnemyType()
        {
            _settingType = true;
            _animator.SetTrigger("startRoll");
            yield return new WaitForSeconds(0.5f);
            int enemyType = Random.Range(0, 3);
            GetComponent<Collider2D>().enabled = false;
            Instantiate(smokeObject, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.3f);
            Instantiate(enemies[enemyType], transform.position, transform.rotation);
            Die();
        }

        public override void Die()
        {
            EnemyManager.Enemies.Remove(this);
            Destroy(gameObject);
        }
    }
}
