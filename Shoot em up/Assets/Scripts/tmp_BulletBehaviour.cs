using UnityEngine;

namespace JT 
{
	public class tmp_BulletBehaviour : MonoBehaviour
	{
		public Rigidbody2D rigidbody;
		public float bulletVelocity;

		private void OnEnable()
		{
			rigidbody.velocity = transform.up * bulletVelocity;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			gameObject.SetActive(false);
		}
	}
}
