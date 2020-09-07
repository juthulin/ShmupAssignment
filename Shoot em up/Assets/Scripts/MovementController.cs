using UnityEngine;

namespace JT 
{
	public class MovementController : MonoBehaviour
	{
		[SerializeField] private Rigidbody2D _rigidbody;

		private Vector2 _movementVector;
		
		[SerializeField] private float movementForce = 12f;
		
		public float angularVelocity;

		public Vector2 MovementVector
		{
			get => default;
			set => _movementVector = value;
		}

		private void Update()
		{
			AddMovementForce(MovementVector);
		}

		private void AddMovementForce(in Vector2 input)
		{
			_rigidbody.AddForce(input * movementForce, ForceMode2D.Force);
			angularVelocity = _rigidbody.angularVelocity;
		}
	}
}
