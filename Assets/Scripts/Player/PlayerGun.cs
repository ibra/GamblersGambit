using UnityEngine;

namespace Casino.Player
{
    public class PlayerGun : MonoBehaviour
    {
        private Camera _camera;

        [SerializeField] private Transform nozzle;
        [SerializeField] private GameObject bulletPrefab;

        private void Awake()
        {
            _camera = Camera.main;
        }

        void Update()
        {
            HandleRotation();
            HandleShooting();
        }

        private void HandleShooting()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletPrefab, nozzle.position, transform.rotation);
            }
        }

        private void HandleRotation()
        {
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = _camera.ScreenToWorldPoint(mousePosition);
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.up = direction;
        }
    }
}
