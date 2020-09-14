using UnityEngine;

namespace JT 
{
	public class EnemyBrain : MonoBehaviour
	{
		[SerializeField] private TransformMovementController transformMovementController;
		[SerializeField] private float movementSpeed;
		[Header("Sin Movement")]
		[SerializeField] private bool useSinMovement = false;
		[SerializeField] private float amplitude = 1f;
		[SerializeField] private float frequency = 1f;

		public float verticalDirection;
		public float horizontalDirection;

		private void Start()
		{
			//Vector2 movement = new Vector2(0f, verticalDirection);
			//transformMovementController.SetMovementVector(movement);
			transformMovementController.SetMovementSpeed(movementSpeed);
		}

		private void Update()
		{
			if (!useSinMovement) return;
			horizontalDirection = Mathf.Cos(Time.time * frequency) * amplitude;
			Vector2 movement = new Vector2(horizontalDirection, verticalDirection);
			transformMovementController.SetMovementVector(movement);
		}
	}
}
