using UnityEngine;

namespace JT 
{
	public class HomingMissileLauncher : MonoBehaviour, IWeapon
	{
		[SerializeField] private Transform firePoint;
		[SerializeField] private int maxClipSize = 10;
		
		public WeaponType WeaponType => WeaponType.HomingMissile;
		public int MaxClipSize => maxClipSize;
		
		public void Shoot()
		{
			ShootBullet();
		}
		
		private void ShootBullet()
		{
			string itemTag = "PlayerRocket";
			GameObject bullet = ObjectPooler.Instance.GetPooledObject(itemTag);
			bullet.transform.position = firePoint.position;
			bullet.transform.rotation = firePoint.rotation;
			bullet.SetActive(true);
		}
	}
}
