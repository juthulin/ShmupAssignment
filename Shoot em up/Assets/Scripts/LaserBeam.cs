using UnityEngine;

namespace JT 
{
	public class LaserBeam : MonoBehaviour, IWeapon
	{
		[SerializeField] private Transform firePoint;
		[SerializeField] private int maxClipSize = 50;
		
		public WeaponType WeaponType => WeaponType.LaserBeam;
		public int MaxClipSize => maxClipSize;
		
		public void Shoot()
		{
			Debug.Log("BZZZZ!");
		}
	}
}
