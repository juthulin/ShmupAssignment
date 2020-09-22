using System.Collections.Generic;
using UnityEngine;

namespace JT 
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class HomingMissileBehaviour : MonoBehaviour
	{
		private Transform _target;
		private Rigidbody2D _thisRigidbody;
		private bool _hasTarget = false;
		
		[SerializeField] private float missileVelocity;
		[SerializeField] private float rotationSpeed;
		[SerializeField] private int damageAmount;

		private void Awake()
		{
			_thisRigidbody = GetComponent<Rigidbody2D>();
		}

		private void OnEnable()
		{
			_target = FindClosestTarget();
		}

		private void Update()
		{
			_thisRigidbody.velocity = transform.up * missileVelocity;

			if (!_hasTarget || !_target.gameObject.activeInHierarchy)
			{
				_hasTarget = false;
				_target = FindClosestTarget();
				return;
			}
			Vector3 direction = _target.position - transform.position;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
			Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, angleAxis, Time.deltaTime * rotationSpeed);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Border"))
			{
				gameObject.SetActive(false);
				return;
			}

			if (other.CompareTag("Enemy"))
			{
				HealthSystem hit = other.GetComponent<HealthSystem>();
				hit.TakeDamage(damageAmount);
			}
			gameObject.SetActive(false);
		}

		private Transform FindClosestTarget()
		{
			if (EnemySpawner.Instance.spawnedEnemies.Count == 0)
			{
				_hasTarget = false;
				return null;
			}
			
			List<GameObject> targets = EnemySpawner.Instance.spawnedEnemies;
			Transform target = targets[0].transform;
			
			float shortestDistance = 1000f;
			for (int i = 0; i < targets.Count; i++)
			{
				Vector2 direction = targets[i].transform.position - transform.position;
				float distance = direction.magnitude;
				
				if (!(shortestDistance > distance)) continue;
				shortestDistance = distance;
				target = targets[i].transform;
			}

			_hasTarget = true;
			return target;
		}

		private void OnDisable()
		{
			_thisRigidbody.velocity = Vector2.zero;
		}
	}
}
