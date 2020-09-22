using UnityEngine;

namespace JT 
{
	[RequireComponent(typeof(EnemyShootingBehaviour), typeof(TransformMovementController))]
	public class EnemyBrain : MonoBehaviour
	{
		private float _horizontalDirection;
		private float _timeOffset;
		private float _timeBetweenShots = 1f;
		private float _timeSinceLastShot;
		private EnemyShootingBehaviour _enemyShootingBehaviour;
		private TransformMovementController _transformMovementController;

		[SerializeField] private float movementSpeed = 1f;
		[SerializeField] private float verticalDirection = 1f;
		
		[Header("Sin Movement")]
		[SerializeField] private bool useSinMovement = default;
		[SerializeField, Range(.1f, 20f)] private float amplitude = 5f;
		[SerializeField, Range(.1f, 20f)] private float frequency = 3f;
		
		[Header("Shooting")]
		[SerializeField, Range(0f, 19.9f)] private float minTimeBetweenShots = 0.1f;
		[SerializeField, Range(0.1f, 20f)] private float maxTimeBetweenShots = 1f;
		
		private void Awake()
		{
			_enemyShootingBehaviour = GetComponent<EnemyShootingBehaviour>();
			_transformMovementController = GetComponent<TransformMovementController>();
		}

		private void OnEnable()
		{
			_timeOffset = Time.time;
			Vector2 movement = new Vector2(0f, verticalDirection);
			_transformMovementController.SetMovementVector(movement);
			_transformMovementController.SetMovementSpeed(movementSpeed);
		}

		private void Update()
		{
			_timeSinceLastShot += Time.deltaTime;
			if (_timeSinceLastShot >= _timeBetweenShots)
			{
				ShootAtPlayer();
				_timeSinceLastShot = 0f;
				_timeBetweenShots = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
			}
			
			if (!useSinMovement) return;
			_horizontalDirection = Mathf.Cos(Time.time * frequency - (_timeOffset * frequency)) * amplitude;
			Vector2 movement = new Vector2(_horizontalDirection, verticalDirection);
			_transformMovementController.SetMovementVector(movement);
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
			_enemyShootingBehaviour.Shoot(angle);
		}

		public void OnDeath()
		{
			EnemySpawner.Instance.spawnedEnemies.Remove(gameObject);
			gameObject.SetActive(false);
		}

		private void OnValidate()
		{
			if (maxTimeBetweenShots < minTimeBetweenShots)
			{
				maxTimeBetweenShots = minTimeBetweenShots + 0.1f;
			}

			if (verticalDirection > 0f) verticalDirection = 1f;
			if (verticalDirection < 0f) verticalDirection = -1f;
		}
	}
}
