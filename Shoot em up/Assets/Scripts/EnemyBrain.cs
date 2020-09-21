using UnityEngine;

namespace JT 
{
	public class EnemyBrain : MonoBehaviour
	{
		private float _horizontalDirection;
		private float _offset;
		private float _timeBetweenShots = 1f;
		private float _timeSinceLastShot;

		[SerializeField] private EnemyShootingBehaviour enemyShootingBehaviour;
		[SerializeField] private TransformMovementController transformMovementController;
		[SerializeField] private float movementSpeed;
		[SerializeField] private float verticalDirection;
		
		[Header("Sin Movement")]
		[SerializeField] private bool useSinMovement = false;
		[SerializeField] private float amplitude = 1f;
		[SerializeField] private float frequency = 1f;
		
		[Header("Shooting")]
		[SerializeField, Range(0f, 19.9f)] private float randomMinValue = 0.1f;
		[SerializeField, Range(0.1f, 20f)] private float randomMaxValue = 1f;


		private void OnEnable()
		{
			_offset = Time.time;
			Vector2 movement = new Vector2(0f, verticalDirection);
			transformMovementController.SetMovementVector(movement);
			transformMovementController.SetMovementSpeed(movementSpeed);
		}

		private void Update()
		{
			_timeSinceLastShot += Time.deltaTime;
			if (_timeSinceLastShot >= _timeBetweenShots)
			{
				ShootAtPlayer();
				_timeSinceLastShot = 0f;
				_timeBetweenShots = Random.Range(randomMinValue, randomMaxValue);
			}
			
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

		private void ShootAtPlayer()
		{
			Vector3 direction = PlayerBrain.Instance.transform.position - transform.position;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
			enemyShootingBehaviour.Shoot(angle);
		}

		public void OnDeath()
		{
			EnemySpawner.Instance.spawnedEnemies.Remove(gameObject);
			gameObject.SetActive(false);
		}

		private void OnValidate()
		{
			if (randomMaxValue < randomMinValue)
			{
				randomMaxValue = randomMinValue + 0.1f;
			}
		}
	}
}
