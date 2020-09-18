
namespace JT 
{
	public interface IWeapon
	{
		WeaponType WeaponType { get; }

		void Shoot(bool shouldFire);

		void SetRateOfFire(float rateOfFire);
		
	}
}
