using System.Collections.Generic;
using UnityEngine;

namespace JT 
{
	public class ShootingBehaviour : MonoBehaviour
	{
		private IWeapon _currentWeapon;
		private readonly List<WeaponType> _weapons = new List<WeaponType>();
		private bool _shouldFire = default;
		[SerializeField] private WeaponContainer weaponContainer;
		[SerializeField] private RevolvingWeaponBehaviour revolvingWeaponBehaviour;

		private void Awake()
		{
			_weapons.Add(WeaponType.DefaultBlaster);
			EquipWeapon(_weapons[0]);
		}

		private void Update()
		{
			_currentWeapon.SetRateOfFire(Mathf.Abs(revolvingWeaponBehaviour.RevolvingSpeed));
		}

		public void CheckToFireWeapon(in bool shouldFire)
		{
			_shouldFire = shouldFire;
			revolvingWeaponBehaviour.Firing = _shouldFire;
			_currentWeapon?.Shoot(_shouldFire);
		}

		private void EquipWeapon(WeaponType weaponType)
		{
			GameObject weapon = ((MonoBehaviour) _currentWeapon)?.gameObject;
			if(weapon != null)
			{
				Destroy(weapon);
			}

			_currentWeapon = Instantiate(weaponContainer.GetWeapon(weaponType), transform, false).GetComponent<IWeapon>();
			_currentWeapon?.Shoot(_shouldFire);
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
