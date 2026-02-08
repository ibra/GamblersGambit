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
        private void UpdateSprite(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle = (angle + 360f) % 360f;

            Sprite sprite = null;
            int order = 0;

            if (angle >= 337.5f || angle < 22.5f)       // Right
                sprite = gunSprites[0];
            else if (angle < 67.5f)                     // Up-Right
                sprite = gunSprites[1];
            else if (angle < 112.5f)                    // Up
                sprite = gunSprites[2];
            else if (angle < 157.5f)                    // Up-Left
                sprite = gunSprites[3];
            else if (angle < 202.5f)                    // Left
                sprite = gunSprites[4];
            else if (angle < 247.5f)                    // Down-Left
                sprite = gunSprites[5];
            else if (angle < 292.5f)                    // Down
                sprite = gunSprites[6];
            else                                        // Down-Right
                sprite = gunSprites[7];

            //order = (angle >= 67.5f && angle <= 247.5f) ? 5 : -1;
            //_spriteRenderer.sortingOrder = order;

            _spriteRenderer.sprite = sprite;

        }
    }
}
