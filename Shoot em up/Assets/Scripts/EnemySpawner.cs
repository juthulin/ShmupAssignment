using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JT 
{
	[System.Serializable]
	public class SpawnPatterns
	{
		public int amountToSpawn;
		public float spawnDelay;
	}
	public class EnemySpawner : MonoBehaviour
	{
		private int _spawnCounter = 0;
		
		[SerializeField] private SpawnPatterns[] spawnPatterns;
		[SerializeField] private Transform[] spawnPoints;
		[SerializeField] private float waveCooldown = 3;
		[SerializeField] private ObjectType objectType = ObjectType.Enemy;

		public List<GameObject> spawnedEnemies = new List<GameObject>();
		
		public static EnemySpawner Instance { get; private set; }
		
		private void Awake()
		{
			if (Instance != null && Instance != this)
			{
				Destroy(gameObject);
			}
			else
			{
				Instance = this;
			}
		}
		
		private void Start()
		{
			InitEnemySpawn();
		}

		private void InitEnemySpawn()
		{
			GetRandomNumber(out int rndPattern, spawnPatterns.Length);
			GetRandomNumber(out int rndSpawn, spawnPoints.Length);
			StartCoroutine(SpawnEnemy(rndPattern, rndSpawn));
		}

		private void GetEnemy(out GameObject enemy)
		{
			enemy = ObjectPooler.Instance.GetPooledObject(objectType);
		}

		private IEnumerator SpawnEnemy(int rndPattern, int rndSpawn)
		{
			_spawnCounter = 0;
			while (_spawnCounter < spawnPatterns[rndPattern].amountToSpawn)
			{
				GetEnemy(out GameObject enemy);
				spawnedEnemies.Add(enemy);

				enemy.transform.position = spawnPoints[rndSpawn].position;
				enemy.SetActive(true);

				_spawnCounter++;
				yield return new WaitForSeconds(spawnPatterns[rndPattern].spawnDelay);
			}

			StartCoroutine(WaveCooldown());
		}

		private IEnumerator WaveCooldown()
		{
			yield return new WaitForSeconds(waveCooldown);
			InitEnemySpawn();
		}

		private static void GetRandomNumber(out int x, in int max)
		{
			x = Random.Range(0, max);
		}
	}
}
