using System;
using System.Collections.Generic;
using UnityEngine;

namespace Casino.General
{
    [Serializable]
    internal class SpriteAngle
    {
        public Sprite sprite;
        public float angle;
    }
    
    public class SpriteRotate : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        
        [SerializeField] private List<SpriteAngle> spriteAngles;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            _spriteRenderer.sprite = CalculateSprite(transform.rotation.z);
        }

        private Sprite CalculateSprite(float angle)
        {
            foreach (SpriteAngle VARIABLE in spriteAngles)
            {
                
            }
            
    

            return spriteAngles[0].sprite;
        }
    }
}
