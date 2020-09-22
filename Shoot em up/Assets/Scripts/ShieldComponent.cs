using System.Collections;
using UnityEngine;

namespace JT 
{
	[RequireComponent(typeof(HealthSystem))]
	public class ShieldComponent : MonoBehaviour
	{
		private HealthSystem _playerHealthSystem;
		private bool _shieldCanActivate;
		
		[Header("Required Component")]
		[SerializeField] private GameObject shieldPrefab;
		[Space]
		[SerializeField] private float shieldDuration = 5f;
		[SerializeField] private float shieldCooldown = 5f;
		
		private void Awake()
		{
			_playerHealthSystem = GetComponent<HealthSystem>();
			_shieldCanActivate = true;
			shieldPrefab.SetActive(false);
		}

		public void ActivateShield()
		{
			if (_shieldCanActivate)
				StartCoroutine(ShieldActive());
		}

		private IEnumerator ShieldActive()
		{
			_shieldCanActivate = false;
			
			_playerHealthSystem.Invulnerable = true;
			shieldPrefab.SetActive(true);
			
			yield return new WaitForSeconds(shieldDuration);
			
			_playerHealthSystem.Invulnerable = false;
			shieldPrefab.SetActive(false);

			StartCoroutine(ShieldCooldown());
		}

		private IEnumerator ShieldCooldown()
		{
			yield return new WaitForSeconds(shieldCooldown);
			_shieldCanActivate = true;
		}
	}
}
