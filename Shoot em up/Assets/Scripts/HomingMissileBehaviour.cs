using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JT 
{
	public class HomingMissileBehaviour : MonoBehaviour
	{
		private Transform _target;
		//private bool _hasTarget;
		private bool _coroutineOnGoing;
		[SerializeField] private Rigidbody2D thisRigidbody;
		[SerializeField] private float missileVelocity;
		[SerializeField] private float rotationSpeed;
		[SerializeField] private int damageAmount;

		private void OnEnable()
		{
			_target = FindClosestTarget();
		}

		private void Update()
		{
			thisRigidbody.velocity = transform.up * missileVelocity;

			if (_target == null || !_target.gameObject.activeInHierarchy)
			{
				_target = FindClosestTarget();
				// if (!_coroutineOnGoing)
				// {
				// 	StartCoroutine(FindNewTarget());
				// }
				return;
			}
			Vector3 direction = _target.position - transform.position;
			Debug.DrawRay(transform.position, direction, Color.green);
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
				//_hasTarget = false;
				return null;
			}
			
			List<GameObject> targets = EnemySpawner.Instance.spawnedEnemies;
			Transform target = targets[0].transform;
			
			float shortest = 0f;
			for (int i = 0; i < targets.Count; i++)
			{
				Vector2 direction = targets[i].transform.position - transform.position;
				float distance = direction.magnitude;
				if (shortest > distance || shortest == 0)
				{
					shortest = distance;
					target = targets[i].transform;
				}
			}

			//_hasTarget = true;
			return target;
		}

		private IEnumerator FindNewTarget()
		{
			_coroutineOnGoing = true;
			yield return new WaitForSeconds(0.1f);
			FindClosestTarget();
			_coroutineOnGoing = false;
		}

		private void OnDisable()
		{
			thisRigidbody.velocity = Vector2.zero;
		}
	}
}
