using UnityEngine;

namespace JT 
{
	public class HomingMissileLauncher : MonoBehaviour, IWeapon
	{
		private float _timeBetweenShots = default;
		private float _timeSinceLastShot = default;
		private bool _fireWeapon = default;
		private float _fireRate = default;
		private bool _fireLeft = default;
		[SerializeField] private ObjectType objectToFire;
		[SerializeField] private Transform firePointLeft;
		[SerializeField] private Transform firePointRight;

		public WeaponType WeaponType => WeaponType.HomingMissile;

		private void Update()
		{
			_timeBetweenShots = CalculateTimeBetweenShots();
			
			_timeSinceLastShot += Time.deltaTime;

			if (!(_timeSinceLastShot > _timeBetweenShots) || !_fireWeapon) return;
			ShootBullet();
			_timeSinceLastShot = 0f;
		}

		public void Shoot(bool shouldFire)
		{
			_fireWeapon = shouldFire;
		}

		public void SetRateOfFire(float rateOfFire)
		{
			_fireRate = rateOfFire * 0.3f;
		}
		
		private float CalculateTimeBetweenShots()
		{
			float x = 60 / _fireRate;
			return x;
		}

		private void ShootBullet()
		{
			GameObject missile = ObjectPooler.Instance.GetPooledObject(objectToFire);

			if (_fireLeft)
			{
				missile.transform.position = firePointLeft.position;
				missile.transform.rotation = firePointLeft.rotation;
				_fireLeft = false;
			}
			else
			{
				missile.transform.position = firePointRight.position;
				missile.transform.rotation = firePointRight.rotation;
				_fireLeft = true;
			}
			missile.SetActive(true);
		}
	}
}
