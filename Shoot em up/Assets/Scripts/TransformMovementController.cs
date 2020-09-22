using UnityEngine;

namespace JT 
{
	public class TransformMovementController : MonoBehaviour
	{
		private Transform _transform;

		private Vector3 InputVector3 { get; set; }
		private float MovementSpeed { get; set; }

		private void Awake()
		{
			_transform = transform;
		}

		private void Update()
		{
			_transform.position += InputVector3 * (MovementSpeed * Time.deltaTime);
		}
		
		public void SetMovementVector(in Vector2 input)
		{
			InputVector3 = input;
		}

		public void SetMovementSpeed(in float movementSpeed)
		{
			MovementSpeed = -movementSpeed;
		}
	}
}
