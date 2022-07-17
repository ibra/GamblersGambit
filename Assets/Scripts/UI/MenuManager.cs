using UnityEngine;
using UnityEngine.SceneManagement;

namespace Casino
{
    public class MenuManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
