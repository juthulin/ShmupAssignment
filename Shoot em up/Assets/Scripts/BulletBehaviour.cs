using UnityEngine;

namespace JT 
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class BulletBehaviour : MonoBehaviour
	{
		private Rigidbody2D _thisRigidbody;
		[SerializeField] private float bulletVelocity;
		public int damageAmount = 10;

		private void Awake()
		{
			_thisRigidbody = GetComponent<Rigidbody2D>();
		}

		private void OnEnable()
		{
			_thisRigidbody.velocity = transform.up * bulletVelocity;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Border") || other.CompareTag("Shield"))
			{
				gameObject.SetActive(false);
				return;
			}
			
			HealthSystem hit = other.GetComponent<HealthSystem>();
			if (hit != null)
			{
				hit.TakeDamage(damageAmount);
			}
			gameObject.SetActive(false);
		}

		private void OnDisable()
		{
			_thisRigidbody.velocity = Vector2.zero;
		}
	}
}
