using UnityEngine;

namespace JT 
{
	public class tmp_BulletBehaviour : MonoBehaviour
	{
		[SerializeField] private Rigidbody2D thisRigidbody;
		[SerializeField] private float bulletVelocity;
		public int damageAmount = 10;

		private void OnEnable()
		{
			thisRigidbody.velocity = transform.up * bulletVelocity;
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
			thisRigidbody.velocity = Vector2.zero;
		}
	}
}
