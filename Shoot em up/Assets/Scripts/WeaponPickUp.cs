using UnityEngine;

namespace JT 
{
	public class WeaponPickUp : MonoBehaviour
	{
		[SerializeField] private WeaponType weaponType;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
			{
				other.gameObject.GetComponent<ShootingBehaviour>().PickUpWeapon(weaponType);
				gameObject.SetActive(false);
			}
		}
	}
}
