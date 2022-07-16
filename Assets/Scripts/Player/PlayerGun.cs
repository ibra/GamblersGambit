using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Casino.Player
{
    public class PlayerGun : MonoBehaviour
    {
        private Camera _camera;
        private SpriteRenderer _spriteRenderer;

        private PlayerMovement _playerMovement;
        private SpriteRenderer _playerSpriteRenderer;
 
        private Vector2 _direction;

        [Header("Bullets")] 
        private int _bullets;
        [SerializeField] private TextMeshProUGUI bulletText;
        [SerializeField] private int maxBullets;
        [SerializeField] public Transform nozzle;
        
        [Header("Bullet Randomness")] 
        private int _bulletType;
        [SerializeField] private GameObject[] bulletPrefab;

        [Header("Gun")]
        [SerializeField] private Sprite[] gunSprites;

        [Header("Reloading")] 
        private bool _reloading;
        [SerializeField] private float reloadTime = 2f;

        private void Awake()
        {
            _bullets = maxBullets;
            _camera = Camera.main;
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _playerSpriteRenderer = transform.parent.Find("Sprite").GetComponent<SpriteRenderer>();
            _playerMovement = GetComponentInParent<PlayerMovement>();
        }

        private void Start()
        {
            GetRandomBulletType();
        }

        private void GetRandomBulletType()
        {
            string[] possibilities = { "y", "r", "b" };
            string combination = "";
            combination += possibilities[Random.Range(0,3)] + possibilities[Random.Range(0, 3)] + possibilities[Random.Range(0,3)];
            Debug.Log(combination);
        }

        private void Update()
        {
            HandleRotation();
            HandleShooting();
            UpdateUserInterface();
        }

        private void UpdateUserInterface()
        {
            bulletText.text = $"{_bullets}/{maxBullets}";
        }

        private void HandleShooting()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_bullets > 0)
                {
                    GameObject bullet = Instantiate(bulletPrefab[0], nozzle.position, nozzle.rotation);
                    _bullets--;
                }
                else if (_bullets <= 0 && !_reloading)
                {
                    StartCoroutine(Reload());
                }
            }
            if (Input.GetKeyDown(KeyCode.R) && _bullets <= 0 && !_reloading) 
                StartCoroutine(Reload());
        }

        private IEnumerator Reload()
        {
            _reloading = true;
            yield return new WaitForSeconds(reloadTime);
            
            _bullets = maxBullets;
            _reloading = false;
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
            
            if (angle >= 0f && angle <= 45f)
            {
                _playerSpriteRenderer.sprite = _playerMovement.playerSprites[0];
                _spriteRenderer.sprite = gunSprites[4];
                _spriteRenderer.sortingOrder = -1;
            } 
            else if(angle >= 45f && angle <= 90f)
            {
                _playerSpriteRenderer.sprite = _playerMovement.playerSprites[0];
                _spriteRenderer.sprite = gunSprites[3];
                _spriteRenderer.sortingOrder = -1;
            } 
            else if (angle >= 90f && angle <= 135f)
            {
                _spriteRenderer.sprite = gunSprites[2];
                _playerSpriteRenderer.sprite = _playerMovement.playerSprites[1];
                _spriteRenderer.sortingOrder = 5;
            } else if (angle >= 135 && angle <= 175)
            {
                _playerSpriteRenderer.sprite = _playerMovement.playerSprites[2];
                _spriteRenderer.sprite = gunSprites[1];
                _spriteRenderer.sortingOrder = 5;
            }
            else if ((angle >= 175 && angle <= 180)|| (angle >= -175  && angle <= -179))
            {
                _playerSpriteRenderer.sprite = _playerMovement.playerSprites[2];
                _spriteRenderer.sortingOrder = 5;
            }
            else if (angle >= -135 && angle <= -175)
            {
                _playerSpriteRenderer.sprite = _playerMovement.playerSprites[3];
                _spriteRenderer.sprite = gunSprites[6]; //c
                _spriteRenderer.sortingOrder = -1;
            }
            else if (angle >= -135 && angle <= -90f)
            {
                _playerSpriteRenderer.sprite = _playerMovement.playerSprites[3];
                _spriteRenderer.sprite = gunSprites[7];
                _spriteRenderer.sortingOrder = -1;
            }
            else if (angle >= -90f && angle <= -45f)
            {
                _spriteRenderer.sprite = gunSprites[6];
                _spriteRenderer.sortingOrder = -1;
            }
            else if (angle >= -45 && angle < 0f)
            {
                _spriteRenderer.sprite = gunSprites[5];
                _spriteRenderer.sortingOrder = -1;
            }
        }
    }
}
