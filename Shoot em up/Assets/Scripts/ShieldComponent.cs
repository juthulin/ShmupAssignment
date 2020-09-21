using System.Collections;
using UnityEngine;

namespace JT 
{
	public class ShieldComponent : MonoBehaviour
	{
		private bool _shieldCanActivate;
		[Header("Required Components")]
		[SerializeField] private HealthSystem playerHealthSystem;
		[Space]
		[SerializeField] private GameObject shieldPrefab;
		[SerializeField] private float shieldDuration = 5f;
		[SerializeField] private float shieldCooldown = 5f;
		
		private void Awake()
		{
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
			playerHealthSystem.Invulnerable = true;
			shieldPrefab.SetActive(true);
			
			yield return new WaitForSeconds(shieldDuration);
			
			playerHealthSystem.Invulnerable = false;
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
