using UnityEngine;
using UnityEngine.InputSystem;

namespace JT 
{
	public class PlayerBrain : MonoBehaviour
	{
		private MainInput _controls;
		[SerializeField] private MovementController movementController;
		[SerializeField] private PlayerShooting playerShooting;

		private void Awake()
		{
			_controls = new MainInput();

			_controls.MainScene.Movement.performed += PlayerMovement;
			_controls.MainScene.Movement.canceled += PlayerMovement;
			_controls.MainScene.Shooting.performed += Shooting;
			_controls.MainScene.Shooting.canceled += Shooting;
			_controls.MainScene.MouseDeltaX.performed += MouseDeltaX;
			_controls.MainScene.MouseDeltaX.canceled += MouseDeltaX;
			_controls.MainScene.MouseRightClick.performed += RightClick;
			_controls.MainScene.MouseRightClick.canceled += RightClick;
			
			_controls.Enable();
		}

		private void OnEnable()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}

		private void PlayerMovement(InputAction.CallbackContext context)
		{
			movementController.MovementVector = context.ReadValue<Vector2>();
		}

		private void Shooting(InputAction.CallbackContext context)
		{
			playerShooting.CheckToFireWeapon(context.ReadValueAsButton());
		}

		private void MouseDeltaX(InputAction.CallbackContext context)
		{
			playerShooting.RotateSpinner(Mathf.Clamp(context.ReadValue<float>(), -1f, 1f));
		}

		private void RightClick(InputAction.CallbackContext context)
		{
			playerShooting.RightMButtonIsHeld = context.ReadValueAsButton();
		}

		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
