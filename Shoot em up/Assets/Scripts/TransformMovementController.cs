using UnityEngine;

namespace JT 
{
	public class TransformMovementController : MonoBehaviour
	{
		public float amplitude = 1f;
		public float frequency = 1f;
		public float offset = 0f;
		
		private Transform _transform;

		private Vector3 InputVector3 { get; set; }
		private float MovementSpeed { get; set; }

		private void Awake()
		{
			_transform = transform;
		}

		private void Update()
		{
			//_transform.position += InputVector3 * (MovementSpeed * Time.deltaTime);
			float x = Mathf.Cos(Time.time * frequency + offset) * amplitude;
			float y = Mathf.Sin(Time.time * frequency + offset) * amplitude;
			_transform.position = new Vector3(x, y,0);
		}
		
		public void SetMovementVector(Vector2 input)
		{
			InputVector3 = input;
		}

		public void SetMovementSpeed(float movementSpeed)
		{
			MovementSpeed = -movementSpeed;
		}
	}
}
