using System.Collections;
using UnityEngine;

namespace JT 
{
	[RequireComponent(typeof(LineRenderer))]
	public class LaserBeam : MonoBehaviour, IWeapon
	{
		private LineRenderer _lineRenderer;
		private Coroutine _coroutine;
		private float _laserWidth;
		private bool _fireWeapon = false;
		
		[Header("Required Component")]
		[SerializeField] private Transform firePoint;
		[Space]
		[SerializeField] private LayerMask layerMask;
		[SerializeField] private int damageAmount;
		[SerializeField] private float rateOfFire;
		

		public WeaponType WeaponType => WeaponType.LaserBeam;

		private void Awake()
		{
			_lineRenderer = GetComponent<LineRenderer>();
		}

		private void Update()
		{
			if (_fireWeapon)
			{
				DrawLine();
			}
		}

		private void DrawLine()
		{
			Vector3 thisPosition = transform.position;
			Vector3[] positions = new Vector3[2];
			positions[0] = thisPosition;
			positions[1] = new Vector3(thisPosition.x, 6f, 0f);
			_lineRenderer.SetPositions(positions);
			_lineRenderer.widthMultiplier = _laserWidth;
		}

		public void Shoot(in bool shouldFire)
		{
			_fireWeapon = shouldFire;
			_lineRenderer.enabled = _fireWeapon;
			if (_fireWeapon) StartCoroutine(FireWeapon());
			else StopAllCoroutines();
		}

		public void SetRateOfFire(in float interval)
		{
			_laserWidth = interval * 0.001f;
		}

		private void FireLaser()
		{
			RaycastHit2D[] hits = Physics2D.CircleCastAll(firePoint.position, _laserWidth * 0.4f, Vector2.up, 10, layerMask);
			for (int i = 0; i < hits.Length; i++)
			{
				HealthSystem hit = hits[i].transform.GetComponent<HealthSystem>();
				hit.TakeDamage(damageAmount);
			}
			Debug.DrawRay(firePoint.position, Vector3.up * 10, Color.green, .1f);
		}

		private IEnumerator FireWeapon()
		{
			while (true)
			{
				if (_laserWidth > 0.1f) FireLaser();
				yield return new WaitForSeconds(rateOfFire);
			}
		}
	}
}
