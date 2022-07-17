using UnityEngine;

namespace Casino.Bullets
{
    public class YellowBullet : Bullet
    {
        public bool recursive; 
        [SerializeField] private GameObject bulletPrefab;

        private void Start()
        {
            if(recursive)
                return;
            
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0,0,35)).GetComponent<YellowBullet>().recursive = true;
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0,0,-35)).GetComponent<YellowBullet>().recursive = true;
        }
    }
}
