using System;
using UnityEngine;

namespace Casino.Audio
{
    public class AudioManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
