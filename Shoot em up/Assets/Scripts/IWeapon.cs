
namespace JT 
{
	public interface IWeapon
	{
		WeaponType WeaponType { get; }
		
		int MaxClipSize { get; }
		
		void Shoot(bool shouldFire);

		void SetRateOfFire(float rateOfFire);
		
	}
}
