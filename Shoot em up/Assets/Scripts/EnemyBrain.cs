using UnityEngine;

namespace JT 
{
	public class EnemyBrain : MonoBehaviour
	{
		private float _horizontalDirection;
		private float _offset;

		[SerializeField] private TransformMovementController transformMovementController;
		[SerializeField] private float movementSpeed;
		[SerializeField] private float verticalDirection;
		
		[Header("Sin Movement")]
		[SerializeField] private bool useSinMovement = false;
		[SerializeField] private float amplitude = 1f;
		[SerializeField] private float frequency = 1f;


		private void OnEnable()
		{
			_offset = Time.time;
			Vector2 movement = new Vector2(0f, verticalDirection);
			transformMovementController.SetMovementVector(movement);
			transformMovementController.SetMovementSpeed(movementSpeed);
		}

		private void Update()
		{
			if (!useSinMovement) return;
			_horizontalDirection = Mathf.Cos(Time.time * frequency - (_offset * frequency)) * amplitude;
			Vector2 movement = new Vector2(_horizontalDirection, verticalDirection);
			transformMovementController.SetMovementVector(movement);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Border"))
			{
				OnDeath();
			}
		}

		public void OnDeath()
		{
			EnemySpawner.Instance.spawnedEnemies.Remove(gameObject);
			gameObject.SetActive(false);
		}
	}
}
