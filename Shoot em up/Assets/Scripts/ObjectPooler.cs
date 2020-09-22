using System.Collections.Generic;
using UnityEngine;

namespace JT 
{
	[System.Serializable]
	public class ObjectPoolItem
	{
		public int amountToPool;
		public bool shouldExpand = default;
		public GameObject objectToPool;
		public ObjectType objectType;
	}

	[System.Serializable]
	public class Pool
	{
		public List<GameObject> pooledObjects = new List<GameObject>();
	}
	
	[DefaultExecutionOrder(-50)]
	public class ObjectPooler : MonoBehaviour
	{
		private readonly Dictionary<ObjectType, Pool> _mappedPools = new Dictionary<ObjectType, Pool>();

		[SerializeField] private List<ObjectPoolItem> itemsToPool;
		[SerializeField] private List<Pool> listOfPools;
		
		public static ObjectPooler Instance { get; private set; }

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
			listOfPools = new List<Pool>();
			
			foreach (ObjectPoolItem item in itemsToPool)
			{
				Pool pool = new Pool();
				listOfPools.Add(pool);
				_mappedPools.Add(item.objectType, pool);
				
				for (int i = 0; i < item.amountToPool; i++)
				{
					GameObject obj = Instantiate(item.objectToPool, transform);
					obj.SetActive(false);
					pool.pooledObjects.Add(obj);
				}
			}
		}

		public GameObject GetPooledObject (in ObjectType objectType)
		{
			if (!_mappedPools.ContainsKey(objectType)) return null;

			List<GameObject> specifiedPool = _mappedPools[objectType].pooledObjects;

			for (int i = 0; i < specifiedPool.Count; i++)
			{
				if (!specifiedPool[i].activeInHierarchy)
				{
					return specifiedPool[i];
				}
			}

			foreach (ObjectPoolItem item in itemsToPool)
			{
				if (item.objectType != objectType || !item.shouldExpand) continue;
				
				GameObject obj = Instantiate(item.objectToPool, transform);
				obj.SetActive(false);
				specifiedPool.Add(obj);
				return obj;
			}
			
			return null;
		}
	}
}
