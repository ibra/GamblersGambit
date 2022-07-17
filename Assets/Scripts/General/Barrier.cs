using UnityEngine;
using UnityEngine.SceneManagement;

namespace Casino
{
    public class Barrier : MonoBehaviour
    {
        public bool isOpen;
        
        // ReSharper disable Unity.PerformanceAnalysis
        public void Open()
        {
            isOpen = true;
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log(col.name);
            if (col.CompareTag("Player") && isOpen)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
