using UnityEngine;

namespace JT 
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class RigidbodyMovementController : MonoBehaviour
	{
		private Rigidbody2D _rigidbody;

		[SerializeField] private float movementForce = 12f;

		public Vector2 MovementVector { get; set; }

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			AddMovementForce(MovementVector);
		}

		private void AddMovementForce(in Vector2 input)
		{
			_rigidbody.AddForce(input * movementForce, ForceMode2D.Force);
		}
	}
}
