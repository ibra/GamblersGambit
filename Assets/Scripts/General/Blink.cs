using System.Collections;
using TMPro;
using UnityEngine;

namespace YourShot.Utilities
{
	public class Blink : MonoBehaviour
	{
		private TextMeshProUGUI _text;
		public float blinkTime = 0.5f;

		[SerializeField] private bool allowedToBlink = true;

		private void Awake()
		{
			_text = GetComponent<TextMeshProUGUI>();
		}

		private void OnEnable()
		{
		 StartCoroutine(BlinkEffect());
		}

		private IEnumerator BlinkEffect()
		{
			if (!allowedToBlink) yield break;
			
			_text.enabled = !_text.enabled;
			yield return new WaitForSeconds(blinkTime);
			StartCoroutine(BlinkEffect());
		}
	}


}