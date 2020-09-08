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
	}
	public class ObjectPooler : MonoBehaviour
	{
		public static ObjectPooler Instance { get; private set; }

		public List<ObjectPoolItem> itemsToPool;
		public List<GameObject> pooledObjects;

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
			pooledObjects = new List<GameObject>();
			foreach (ObjectPoolItem item in itemsToPool)
			{
				for (int i = 0; i < item.amountToPool; i++)
				{
					GameObject obj = Instantiate(item.objectToPool, transform);
					obj.SetActive(false);
					pooledObjects.Add(obj);
				}
			}
		}

		public GameObject GetPooledObject(string itemTag)
		{
			for (int i = 0; i < pooledObjects.Count; i++)
			{
				if(!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == itemTag)
				{
					return pooledObjects[i];
				}
			}

			foreach (ObjectPoolItem item in itemsToPool)
			{
				if (item.objectToPool.tag == itemTag)
				{
					if (item.shouldExpand)
					{
						GameObject obj = Instantiate(item.objectToPool, transform);
						obj.SetActive(false);
						pooledObjects.Add(obj);
						return obj;
					}
				}
			}

			return null;
		}
	}
}
