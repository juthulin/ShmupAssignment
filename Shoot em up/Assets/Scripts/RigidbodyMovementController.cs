using UnityEngine;

namespace JT 
{
	public class RigidbodyMovementController : MonoBehaviour
	{
		[SerializeField] private Rigidbody2D _rigidbody;

		[SerializeField] private float movementForce = 12f;

		public Vector2 MovementVector { get; set; }

		private void Update()
		{
			AddMovementForce(MovementVector);
		}

		private void AddMovementForce(in Vector2 input)
		{
			_rigidbody.AddForce(input * movementForce, ForceMode2D.Force);
			//_rigidbody.velocity = input * movementForce;
		}
	}
}
