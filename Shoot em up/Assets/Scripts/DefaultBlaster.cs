using UnityEngine;

namespace JT 
{
	public class DefaultBlaster : MonoBehaviour, IWeapon
	{
		[SerializeField] private Transform firePoint;
		[SerializeField] private int maxClipSize = 100;
		
		public WeaponType WeaponType => WeaponType.DefaultBlaster;
		public int MaxClipSize => maxClipSize;

		public void Shoot()
		{
			ShootBullet();
		}

		private void ShootBullet()
		{
			string itemTag = "PlayerBullet";
			GameObject bullet = ObjectPooler.Instance.GetPooledObject(itemTag);
			bullet.transform.position = firePoint.position;
			bullet.transform.rotation = firePoint.rotation;
			bullet.SetActive(true);
		}
	}
}
