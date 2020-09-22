using UnityEngine;

namespace JT 
{
	public class EnemyShootingBehaviour : MonoBehaviour
	{
		[SerializeField] private ObjectType objectType = ObjectType.EnemyBullet;
		
		public void Shoot(in float shootingAngle)
		{
			GameObject bullet = ObjectPooler.Instance.GetPooledObject(objectType);
			bullet.transform.position = transform.position;
			bullet.transform.eulerAngles = Vector3.forward * shootingAngle;
			bullet.SetActive(true);
		}
	}
}
