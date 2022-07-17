using System;
using UnityEngine;

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
        }
    }
}
