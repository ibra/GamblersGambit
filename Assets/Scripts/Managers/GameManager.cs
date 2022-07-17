using UnityEngine;
using UnityEngine.SceneManagement;

namespace Casino
{
    public class GameManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(0);
            }
        }
    }
}
