using UnityEngine;

namespace Casino.General
{
    public class DestroyTime : MonoBehaviour
    {
        [SerializeField] private float time = 2f;

        private void OnEnable()
        {
            Destroy(gameObject, time);
        }
    }
}
