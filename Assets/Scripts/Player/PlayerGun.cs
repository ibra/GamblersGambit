using System.Linq.Expressions;
using Unity.Mathematics;
using UnityEngine;

namespace Casino.Player
{
    public class PlayerGun : MonoBehaviour
    {
        private Camera _camera;
        private SpriteRenderer _spriteRenderer;
        private Vector2 _direction;
        
        [SerializeField] private Transform nozzle;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Sprite[] gunSprites;
    


        private void Awake()
        {
            _camera = Camera.main;
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            HandleRotation();
            HandleShooting();
        }

        private void HandleShooting()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);
                // bullet.transform.up = _direction;
            }
        }

        private void HandleRotation()
        {
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = _camera.ScreenToWorldPoint(mousePosition);
            _direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            nozzle.up = _direction;
            UpdateSprite(_direction);
        }

        // 0 is 180, 1 is 135, 2 is 90....
        private void UpdateSprite(Vector2 direction)
        {
            float angle = Vector2.SignedAngle(transform.up, direction) * -1;
            Debug.Log(angle);

            if (angle >= 0f && angle <= 45f)
            {
                _spriteRenderer.sprite = gunSprites[4];
            } 
            else if(angle >= 45f && angle <= 90f)
            {
                _spriteRenderer.sprite = gunSprites[3];
            } 
            else if (angle >= 90f && angle <= 135f)
            {
                _spriteRenderer.sprite = gunSprites[2];
            } else if (angle >= 135 && angle <= 175)
            {
                _spriteRenderer.sprite = gunSprites[1];
            }
            else if ((angle >= 175 && angle <= 180)|| (angle >= -175  && angle <= -179))
            {
                _spriteRenderer.sprite = gunSprites[0];
            }
            else if (angle >= -135 && angle <= -175)
            {
                _spriteRenderer.sprite = gunSprites[6]; //c
            }
            else if (angle >= -135 && angle <= -90f)
            {
                _spriteRenderer.sprite = gunSprites[7];
            }
            else if (angle >= -90f && angle <= -45f)
            {
                _spriteRenderer.sprite = gunSprites[6];
            }
            else if (angle >= -45 && angle < 0f)
            {
                _spriteRenderer.sprite = gunSprites[5];
            }

        }
    }
}
