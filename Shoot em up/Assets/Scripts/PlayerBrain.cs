using UnityEngine;
using UnityEngine.InputSystem;

namespace JT 
{
	public class PlayerBrain : MonoBehaviour
	{
		private MainInput _controls;
		[SerializeField] private MovementController movementController;
		[SerializeField] private ShootingBehaviour shootingBehaviour;
		[SerializeField] private RevolvingWeaponBehaviour revolvingWeaponBehaviour;

		private void Awake()
		{
			_controls = new MainInput();

			_controls.MainScene.Movement.performed += PlayerMovement;
			_controls.MainScene.Movement.canceled += PlayerMovement;
			_controls.MainScene.Shooting.performed += Shooting;
			_controls.MainScene.Shooting.canceled += Shooting;
			_controls.MainScene.MouseDeltaX.performed += MouseDeltaX;
			_controls.MainScene.MouseDeltaX.canceled += MouseDeltaX;
			// _controls.MainScene.MouseRightClick.performed += RightClick;
			// _controls.MainScene.MouseRightClick.canceled += RightClick;
			_controls.MainScene.SwitchWeaponPositive.performed += SwitchWeaponPositive;
			_controls.MainScene.SwitchWeaponNegative.performed += SwitchWeaponNegative;

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
			shootingBehaviour.CheckToFireWeapon(context.ReadValueAsButton());
		}

		private void MouseDeltaX(InputAction.CallbackContext context)
		{
			revolvingWeaponBehaviour.SetRevolvingSpeed(Mathf.Clamp(context.ReadValue<float>(), -1f, 1f));
		}

		// private void RightClick(InputAction.CallbackContext context)
		// {
		// 	shootingBehaviour.RightMButtonIsHeld = context.ReadValueAsButton();
		// }

		private void SwitchWeaponPositive(InputAction.CallbackContext context)
		{
			shootingBehaviour.SwitchWeapon(true);
		}

		private void SwitchWeaponNegative(InputAction.CallbackContext context)
		{
			shootingBehaviour.SwitchWeapon(false);
		}

		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
