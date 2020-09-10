using System.Collections.Generic;
using UnityEngine;

namespace JT 
{
	public class ShootingBehaviour : MonoBehaviour
	{
		//private Transform _thisTransform;
		private IWeapon _currentWeapon;
		private readonly List<WeaponType> _weapons = new List<WeaponType>();
		[SerializeField] private WeaponContainer weaponContainer;

		//public bool RightMButtonIsHeld { get; set; }

		private void Awake()
		{
			//_thisTransform = transform;
			_weapons.Add(WeaponType.DefaultBlaster);
			EquipWeapon(_weapons[0]);
		}

		public void CheckToFireWeapon(bool shouldFire)
		{
			if (shouldFire)
			{
				_currentWeapon?.Shoot();
			}
		}

		private void EquipWeapon(WeaponType weaponType)
		{
			GameObject weapon = ((MonoBehaviour) _currentWeapon)?.gameObject;
			if(weapon != null)
			{
				Destroy(weapon);
			}

			_currentWeapon = Instantiate(weaponContainer.GetWeapon(weaponType), transform, false).GetComponent<IWeapon>();
		}

		public void PickUpWeapon(WeaponType weaponType)
		{
			if(_weapons.Contains(weaponType))
			{
				return;
			}
			_weapons.Add(weaponType);
			EquipWeapon(_weapons[_weapons.Count -1]);
		}

		public void SwitchWeapon(bool cyclePositive)
		{
			if (_currentWeapon == null)
			{
				EquipWeapon(_weapons[0]);
				return;
			}
			
			int currentWeaponIndex = _weapons.IndexOf(_currentWeapon.WeaponType);
			
			EquipWeapon(cyclePositive
				? _weapons[(currentWeaponIndex + 1) % _weapons.Count]
				: _weapons[currentWeaponIndex == 0 ? _weapons.Count - 1 : currentWeaponIndex - 1]);
		}
	}
}
