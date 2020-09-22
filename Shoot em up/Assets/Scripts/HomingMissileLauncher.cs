using UnityEngine;

namespace JT 
{
	public class HomingMissileLauncher : MonoBehaviour, IWeapon
	{
		private float _timeBetweenShots = default;
		private float _timeSinceLastShot = default;
		private bool _fireWeapon = default;
		private float _rateOfFire = default;
		private bool _fireLeft = default;
		
		[Header("Required Components")]
		[SerializeField] private Transform firePointLeft;
		[SerializeField] private Transform firePointRight;
		[Space]
		[SerializeField] private ObjectType objectToFire;

		public WeaponType WeaponType => WeaponType.HomingMissile;

		private void Update()
		{
			_timeBetweenShots = CalculateTimeBetweenShots();
			
			_timeSinceLastShot += Time.deltaTime;

			if (!(_timeSinceLastShot > _timeBetweenShots) || !_fireWeapon) return;
			ShootBullet();
			_timeSinceLastShot = 0f;
		}

		public void Shoot(in bool shouldFire)
		{
			_fireWeapon = shouldFire;
		}

		public void SetRateOfFire(in float rateOfFire)
		{
			_rateOfFire = rateOfFire * 0.3f;
		}
		
		private float CalculateTimeBetweenShots()
		{
			float x = 60 / _rateOfFire;
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
