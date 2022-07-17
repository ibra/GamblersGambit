using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace YourShot.Utilities
{
    public class Typewriter : MonoBehaviour
    {
        private TextMeshProUGUI _sentenceText;
        private AudioSource _typewriterSound;
        private bool _usingSounds;
        
        [SerializeField] private bool playOnAwake = true;
        [SerializeField] private float scrollSpeed = 2f;
        [SerializeField] private int lettersEachIteration = 1;
        [SerializeField] private UnityEvent OnTypeEnd;

        void Start()
        {
            _sentenceText = GetComponent<TextMeshProUGUI>();
            _usingSounds = true;
            _typewriterSound = GetComponent<AudioSource>();
            if (_typewriterSound == null)
            { 
                _usingSounds = false;
            }
        
            if (!playOnAwake) return;
            StartCoroutine(TypewriterEffect());
        }
    
        private IEnumerator TypewriterEffect()
        {

            _sentenceText.maxVisibleCharacters = 0;
            foreach (char letter in _sentenceText.text.ToCharArray())
            {
                _sentenceText.maxVisibleCharacters += lettersEachIteration;
                if (letter != ' ' && _usingSounds)
                {
                    _typewriterSound.Play();
                }
                yield return new WaitForSeconds(scrollSpeed);
            }
            OnTypeEnd.Invoke();
        }
    
    }
}