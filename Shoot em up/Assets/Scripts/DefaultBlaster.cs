using UnityEngine;

namespace JT 
{
	public class DefaultBlaster : MonoBehaviour, IWeapon
	{
		private float _timeSinceLastShot;
		private float _timeBetweenShots;
		private bool _fireWeapon;
		private float _fireRate;
		
		[SerializeField] private Transform firePoint;
		[SerializeField] private int maxClipSize = 100;
		[SerializeField] private float inaccuracy;
		
		public WeaponType WeaponType => WeaponType.DefaultBlaster;
		public int MaxClipSize => maxClipSize;

		private void Update()
		{
			_timeBetweenShots = CalculateTimeBetweenShots();
			
			_timeSinceLastShot += Time.deltaTime;

			if (!(_timeSinceLastShot > _timeBetweenShots)) return;
			if (!_fireWeapon) return;
			ShootBullet();
			_timeSinceLastShot = 0f;
		}

		public void Shoot(bool shouldFire)
		{
			_fireWeapon = shouldFire;
		}

		public void SetRateOfFire(float rateOfFire)
		{
			_fireRate = rateOfFire;
		}

		private float CalculateTimeBetweenShots()
		{
			float x = 60 / _fireRate;
			return x;
		}

		private void ShootBullet()
		{
			string itemTag = "PlayerBullet";
			GameObject bullet = ObjectPooler.Instance.GetPooledObject(itemTag);
			bullet.transform.position = firePoint.position;
			float rnd = Random.Range(-inaccuracy, inaccuracy);
			Vector3 direction = firePoint.rotation * new Vector3(0f, 0f, rnd);
			bullet.transform.eulerAngles = direction;
			bullet.SetActive(true);
		}
	}
}
