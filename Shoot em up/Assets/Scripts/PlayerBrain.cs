using UnityEngine;
using UnityEngine.InputSystem;

namespace JT 
{
	public class PlayerBrain : MonoBehaviour
	{
		private MainInput _controls;
		[SerializeField] private MovementController _movementController;

		private void Awake()
		{
			_controls = new MainInput();

			_controls.MainScene.Movement.performed += PlayerMovement;
			_controls.MainScene.Movement.canceled += PlayerMovement;
			
			_controls.Enable();
		}

		private void OnEnable()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}

		private void PlayerMovement(InputAction.CallbackContext context)
		{
			_movementController.MovementVector = context.ReadValue<Vector2>();
		}

		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
