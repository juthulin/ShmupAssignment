using UnityEngine;

namespace JT 
{
	public class LaserBeam : MonoBehaviour, IWeapon
	{
		[SerializeField] private Transform firePoint;
		[SerializeField] private LineRenderer lineRenderer;

		public WeaponType WeaponType => WeaponType.LaserBeam;

		private void Update()
		{
			DrawLine();
		}

		private void DrawLine()
		{
			Vector3[] positions = new Vector3[2];
			positions[0] = transform.position;
			positions[1] = new Vector3(transform.position.x, 6f, 0f);
			lineRenderer.SetPositions(positions);
		}

		public void Shoot(bool shouldFire)
		{
			Debug.Log("BZZZZ!");
		}

		public void SetRateOfFire(float rateOfFire)
		{
			
		}
	}
}
