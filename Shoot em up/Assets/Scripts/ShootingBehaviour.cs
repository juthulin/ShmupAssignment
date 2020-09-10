using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace JT 
{
	public class PlayerShooting : MonoBehaviour
	{
		private Transform _thisTransform;
		private Coroutine _lastRoutine = null;
		private IWeapon _currentWeapon;
		private List<IWeapon> _weapons = new List<IWeapon>();
		[SerializeField] private Transform firePoint;
		[SerializeField] private Rigidbody2D spinnerRigidbody;
		[SerializeField, Range(1f, 10f)] private float torqueMultiplier = 1f;
		[SerializeField, Range(500f, 5000f)] private float maxAngularVelocity = 2500f;
		[SerializeField, Range(-500f, -100f)] private float minAngularVelocity = -250f;
		[SerializeField] private float shotStoppingForce = 10f;

		public int currentAmmoCount;
		public int maxAmmoCount;
		private bool canReload = false;
		
		public bool RightMButtonIsHeld { get; set; }

		public float displayTorque;

		private void Awake()
		{
			_thisTransform = transform;
			currentAmmoCount = maxAmmoCount;
			_weapons.Add(_currentWeapon);
		}

		private void Update()
		{
			spinnerRigidbody.transform.position = _thisTransform.position;
			
			//---Remove---v
			displayTorque = spinnerRigidbody.angularVelocity;
			//---Remove---^
			
			if (spinnerRigidbody.angularVelocity > maxAngularVelocity)
			{
				spinnerRigidbody.angularVelocity = maxAngularVelocity;
			}

			if (spinnerRigidbody.angularVelocity < minAngularVelocity)
			{
				spinnerRigidbody.angularVelocity = minAngularVelocity;
			}

			if (currentAmmoCount < maxAmmoCount)
			{
				canReload = true;
			}
			
			if(spinnerRigidbody.angularVelocity < -300f && canReload)
			{
				currentAmmoCount = maxAmmoCount;
				canReload = false;
			}
		}

		public void CheckToFireWeapon(bool shouldFire)
		{
			if (shouldFire)
			{
				
			}
			else
			{
				StopCoroutine(_lastRoutine);
			}
		}

		private void ShootBullet()
		{
			string itemTag = "PlayerBullet";
			GameObject bullet = ObjectPooler.Instance.GetPooledObject(itemTag);
			bullet.transform.position = firePoint.position;
			bullet.transform.rotation = firePoint.rotation;
			bullet.SetActive(true);
		}

		public void RotateSpinner(float torque)
		{
			if (RightMButtonIsHeld)
			{
				spinnerRigidbody.AddTorque(torque * torqueMultiplier);
			}
		}

		// private IEnumerator FireWeapon()
		// {
		// 	while (true)
		// 	{
		// 		float waitBetweenShots;
		// 		if (spinnerRigidbody.angularVelocity > 50f && currentAmmoCount > 0)
		// 		{
		// 			ShootBullet();
		// 			currentAmmoCount--;
		// 			spinnerRigidbody.angularVelocity -= shotStoppingForce;
		// 			waitBetweenShots = 60f / (spinnerRigidbody.angularVelocity * 0.5f);
		// 		}
		// 		else
		// 		{
		// 			waitBetweenShots = 0.1f;
		// 		}
		// 		yield return new WaitForSeconds(waitBetweenShots);
		// 	}
		// }
	}
}
