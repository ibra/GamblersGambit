using System;
using UnityEngine;
using UnityEngine.UI;

namespace Casino
{
    public enum HeartType
    {
        EMPTY = 0,
        QUARTER_25 = 1,
        HALF = 2,
        QUARTER_75 = 3,
        FULL = 4,
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
                HeartType.QUARTER_75 => healthQuarters[1],
                HeartType.HALF => healthQuarters[2],
                HeartType.QUARTER_25 => healthQuarters[3],
                HeartType.EMPTY => healthQuarters[4],
                _ => throw new ArgumentOutOfRangeException(nameof(heartType), heartType, null)
            };
        }
    }
}
