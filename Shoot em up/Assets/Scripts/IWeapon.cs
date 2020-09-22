
namespace JT 
{
	public interface IWeapon
	{
		WeaponType WeaponType { get; }

		void Shoot(in bool shouldFire);

		void SetRateOfFire(in float rateOfFire);
		
	}
}
