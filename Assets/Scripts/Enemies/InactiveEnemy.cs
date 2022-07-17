using System.Collections;
using UnityEngine;

namespace Casino.Enemies.Slot
{
    public class InactiveEnemy : Enemy
    {
        private bool _settingType;
        private Animator _animator;

        [SerializeField] private string animationTriggerName = "startRoll";
        [SerializeField] private GameObject smokeObject;
        [SerializeField] private GameObject[] enemies;

        protected override void Start()
        {
            //if this becomes broken call base.Start();
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
            EnemyManager.AwakeAllEnemies();
            _animator.SetTrigger(animationTriggerName);
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.4f, 0.8f));
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
