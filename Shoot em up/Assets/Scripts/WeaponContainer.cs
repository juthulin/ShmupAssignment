using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JT 
{
	[CreateAssetMenu(menuName = "Containers/WeaponContainer")]
	public class WeaponContainer : ScriptableObject 
	{
		[System.Serializable]
		public struct WeaponMapping
		{
			public WeaponType weaponType;
			public GameObject weaponObject;
		}

		[SerializeField] private List<WeaponMapping> mappedWeapons;

		public GameObject GetWeapon(WeaponType weaponType)
		{
			return mappedWeapons.FirstOrDefault(w => w.weaponType == weaponType).weaponObject;
		}
	}
}
