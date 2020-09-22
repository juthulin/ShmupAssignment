using UnityEngine;

namespace JT 
{
	public class DefaultBlaster : MonoBehaviour, IWeapon
	{
		private float _timeSinceLastShot;
		private float _timeBetweenShots;
		private bool _fireWeapon;
		private float _rateOfFire;

		[Header("Required Component")]
		[SerializeField] private Transform firePoint;
		[Space]
		[SerializeField] private ObjectType objectToFire;
		[SerializeField] private float inaccuracy;
		
		public WeaponType WeaponType => WeaponType.DefaultBlaster;

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
			_rateOfFire = rateOfFire;
		}

		private float CalculateTimeBetweenShots()
		{
			float x = 60 / _rateOfFire;
			return x;
		}

		private void ShootBullet()
		{
			GameObject bullet = ObjectPooler.Instance.GetPooledObject(objectToFire);
			
			bullet.transform.position = firePoint.position;
			
			float rnd = Random.Range(-inaccuracy, inaccuracy);
			Vector3 direction = firePoint.rotation * new Vector3(0f, 0f, rnd);
			bullet.transform.eulerAngles = direction;
			
			bullet.SetActive(true);
		}
	}
}
