
namespace JT 
{
	public interface IWeapon
	{
		WeaponType WeaponType { get; }
		
		int MaxClipSize { get; }
		
		void Shoot();
	}
}
