using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Casino.Player
{
    public class PlayerGun : MonoBehaviour
    {
        private Camera _camera;
        private SpriteRenderer _spriteRenderer;

        private PlayerMovement _playerMovement;
        private Animator _playerAnimator;
 
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
        [SerializeField] private AudioSource reloadSound;
        [SerializeField] private float reloadTime = 2f;
        
        [Header("UI")]
        [SerializeField] private Image[] slotMachineUIImages;
        [SerializeField] private Animator[] slotMachineUIAnimator;
        [SerializeField] private Sprite[] fruitSprites;

        private void Awake()
        {
            _bullets = maxBullets;
            _camera = Camera.main;
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _playerAnimator = transform.parent.GetComponent<Animator>();
            _playerMovement = GetComponentInParent<PlayerMovement>();
        }

        private void Start()
        {
            for (int i = 0; i < slotMachineUIAnimator.Length; i++)
            {
                slotMachineUIImages[i] = slotMachineUIAnimator[i].transform.GetComponent<Image>();
            }
            GetRandomBulletType();
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
                    GameObject bullet = Instantiate(bulletPrefab[_bulletType], nozzle.position, nozzle.rotation);
                    _bullets--;
                }
                else if (_bullets <= 0 && !_reloading)
                {
                    StartCoroutine(Reload());
                }
            }
        }

        private IEnumerator Reload()
        {
            _reloading = true;
            GetRandomBulletType();
            reloadSound.Play();
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
        
        private void GetRandomBulletType()
        {
            foreach (Animator animator in slotMachineUIAnimator)
            {
                animator.enabled = true;
                animator.SetBool("rolling", true);
            }
            string[] possibilities = { "y", "r", "b" };
            string combination = possibilities[Random.Range(0,3)] + possibilities[Random.Range(0, 3)] + possibilities[Random.Range(0,3)];

            int yellowCount = combination.Count(s => s == 'y');
            int redCount = combination.Count(s => s == 'r');
            int blueCount = combination.Count(s => s == 'b');
            StartCoroutine(SetBulletType(yellowCount, redCount, blueCount, combination));
        }

        private IEnumerator SetBulletType(int yellowCount, int redCount, int blueCount, string arrangement)
        {
            yield return new WaitForSeconds(reloadTime);
            foreach (Animator animator in slotMachineUIAnimator)
            {
                animator.SetBool("rolling", false);
                animator.enabled = false;
            }
            if(yellowCount == 2)
            {
                _bulletType = 1;
            }
            else if(redCount == 2)
            {
                _bulletType = 2;
            } 
            else if(blueCount == 2)
            {
                _bulletType = 3;
            }
            else if (yellowCount == 3)
            {
                _bulletType = 4;
            } else if(redCount == 3)
            {
                _bulletType = 5;
            } else if (blueCount == 3)
            {
                _bulletType = 6;
            }
            else
            {
                _bulletType = 0;
            }

            for (int i = 0; i < slotMachineUIImages.Length; i++)
            {
                Image image = slotMachineUIImages[i];
                image.sprite = arrangement[i] switch
                {
                    'y' => fruitSprites[0],
                    'r' => fruitSprites[1],
                    'b' => fruitSprites[2],
                    _ => image.sprite
                };
            }
        }

        // 0 is 180, 1 is 135, 2 is 90....
        private void UpdateSprite(Vector2 direction)
        {
            float angle = Vector2.SignedAngle(transform.up, direction) * -1;
            
            if (angle >= 0f && angle <= 45f)
            {
                _playerAnimator.SetInteger("Direction", 1);
                _spriteRenderer.sprite = gunSprites[4];
                _spriteRenderer.sortingOrder = -1;
            } 
            else if(angle >= 45f && angle <= 90f)
            {
                _playerAnimator.SetInteger("Direction", 1);
                _spriteRenderer.sprite = gunSprites[3];
                _spriteRenderer.sortingOrder = -1;
            } 
            else if (angle >= 90f && angle <= 135f)
            {
                _spriteRenderer.sprite = gunSprites[2];
                _playerAnimator.SetInteger("Direction", 2);
                _spriteRenderer.sortingOrder = 5;
            } else if (angle >= 135 && angle <= 175)
            {
                _playerAnimator.SetInteger("Direction", -1);
                _spriteRenderer.sprite = gunSprites[1];
                _spriteRenderer.sortingOrder = 5;
            }
            else if ((angle >= 175 && angle <= 180)|| (angle >= -175  && angle <= -179))
            {
                _playerAnimator.SetInteger("Direction", -1);
                _spriteRenderer.sortingOrder = 5;
            }
            else if (angle >= -135 && angle <= -175)
            {
                _playerAnimator.SetInteger("Direction", -2);
                _spriteRenderer.sprite = gunSprites[6]; //c
                _spriteRenderer.sortingOrder = -1;
            }
            else if (angle >= -135 && angle <= -90f)
            {
                _playerAnimator.SetInteger("Direction", -2);
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
