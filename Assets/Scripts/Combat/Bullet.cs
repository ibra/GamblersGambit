using System;
using UnityEngine;

namespace Casino.Combat
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void OnEnable()
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);
            Destroy(gameObject, 3f); //TODO: remove this
        }
    }
}
