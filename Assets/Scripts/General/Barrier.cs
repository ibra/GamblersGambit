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
            GetComponent<Collider2D>().enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
           if(col.CompareTag("Player") && isOpen) 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
