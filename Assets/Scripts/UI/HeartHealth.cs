using System;
using UnityEngine;
using UnityEngine.UI;

namespace Casino
{
    public enum HeartType
    {
        EMPTY = 0,
        HALF = 1,
        FULL = 2,
    }
    
    public class HeartHealth : MonoBehaviour
    {
        private Image _heart;
        [SerializeField] private Sprite[] healthQuarters;
        
        private void Awake()
        {
            _heart = GetComponent<Image>();
        }

        public void SetHeart(HeartType heartType)
        {
            _heart.sprite = heartType switch
            {
                HeartType.FULL => healthQuarters[0],
                HeartType.HALF => healthQuarters[1],
                HeartType.EMPTY => healthQuarters[2],
                _ => throw new ArgumentOutOfRangeException(nameof(heartType), heartType, null)
            };
        }
    }
}
