using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Casino.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (instance == null)
                instance = this;
            else
            {
                Destroy(gameObject);
            }
            SceneManager.sceneLoaded += CheckForMenu;
        }

        private void CheckForMenu(Scene scene, LoadSceneMode mode)
        {
            if(scene.buildIndex == 0)
                GetComponent<AudioSource>().Stop();
            else
            {
                if(!GetComponent<AudioSource>().isPlaying)
                    GetComponent<AudioSource>().Play();
            }
        }
    }
}
