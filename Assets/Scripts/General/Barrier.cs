using UnityEngine;
using UnityEngine.SceneManagement;

namespace Casino
{
    public class Barrier : MonoBehaviour
    {
        private Animator _animator;
        [SerializeField] private AudioSource doorOpeningSound;
        public bool isOpen;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void Open()
        {
            if (isOpen) return;
            if(!doorOpeningSound.isPlaying) 
                doorOpeningSound.Play();
           isOpen = true;
           _animator.SetTrigger("open");
           GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player") && isOpen)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
