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
            Instantiate(smokeObject, transform.position, transform.rotation);
            Instantiate(enemies[enemyType], transform.position, transform.rotation);
            Die();
        }
    }
}
